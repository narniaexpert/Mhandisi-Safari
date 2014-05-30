
#include <jni.h>
#include "nativehelper/JNIHelp.h"
#include "utils/Log.h"
#include "utility.h"
#include "p2papi_jni.h"
#include "P2P_API.h"
#include "Adpcm.h"

#ifndef INT64_C
#define INT64_C(c) (c ## LL)
#define UINT64_C(c) (c ## ULL)
#endif


extern "C"
{

#include <libavcodec/avcodec.h>
#include <libavformat/avformat.h>
#include <libavutil/avutil.h>
#include <libavdevice/avdevice.h>
#include <libavfilter/avfilter.h>
#include <libswscale/swscale.h>

}

AVCodecContext   *g_pCodecCtx;
AVCodec       *g_pCodec;
AVFrame       *g_pFrame; 



long g_lHandle = -1;
CAdpcm *g_pAudioAdpcm = NULL;
void _AVDataCallback(long nHandle, int bVideo, char *pData, int len, void *pParam)
{
    Log("_AVDataCallback... nHandle: %ld, bVideo: %d, len: %d", nHandle, bVideo, len);

    /*******************************************************************
            ÒôÊÓÆµÊý¾Ý°üº¬ÒôÊÓÆµÍ·ºÍÊý¾Ý²¿·Ö
        *********************************************************************/
    char PCMBuf[2048] = {0} ;
    
    if(bVideo) /* video */
    {
        //video data
        PAV_HEAD phead = (PAV_HEAD)pData;
        Log("startcode: %x, type: %d, streamid: %d, len: %d", phead->startcode, phead->type, phead->streamid, phead->len);
        //get the video data
        if((unsigned int)len == (sizeof(AV_HEAD) + phead->len))
        {
            //pVideo ¾ÍÊÇÊÓÆµÊý¾Ý
            char *pVideo = pData + sizeof(AV_HEAD);
            if(phead->type == 3) /* MJPEG Êý¾Ý */
            {
            }

            if(phead->type == 0 || phead->type == 1) /* H264 */
            {
                AVPacket avpkt;
                av_init_packet(&avpkt);
                avpkt.data = (unsigned char*)pVideo;
                avpkt.size = phead->len;

            	int consumed_bytes = 0;
                /* ½âÂë */
            	avcodec_decode_video2(g_pCodecCtx, g_pFrame, &consumed_bytes, &avpkt);

                /* ½âÂë³É¹¦ */
                if(consumed_bytes > 0)
                {
                    Log("m_pCodecCtx->width: %d, height: %d", g_pCodecCtx->width, g_pCodecCtx->height);
                }


                
            }
        }
        
    }
    else /* audio */
    {
        PAV_HEAD phead = (PAV_HEAD)pData;
        Log("startcode: %x, type: %d, streamid: %d, len: %d", phead->startcode, phead->type, phead->streamid, phead->len);
        //get the audio data
        if((unsigned int)len == (sizeof(AV_HEAD) + phead->len))
        {
            //pAudio ¾ÍÊÇÒôÆµÊý¾Ý
            char *pAudio = pData + sizeof(AV_HEAD);
            memset(PCMBuf, 0, sizeof(PCMBuf));
            if(phead->len == 512)
            {
                //ÒôÆµÎªADPCM£¬½øÐÐ½âÂë
                g_pAudioAdpcm->ADPCMDecode(pAudio, phead->len, PCMBuf);
            }

            //PCMBuf ÖÐ2048´óÐ¡ÎªPCM Êý¾Ý
            
        }
    }
}

void _MessageCallback(long nHandle, int type, char *msg, int len, void *pParam)
{
    Log("_MessageCallback... nHandle: %ld, type: %d, len: %d", nHandle, type, len);
    
    switch(type)
    {
        case MSG_TYPE_P2P_STATUS:
        {
            int nP2PStatus = *((int*)msg) ;
            Log("MSG_TYPE_P2P_STATUS: %d", nP2PStatus);
        }
            break;
        case MSG_TYPE_P2P_MODE:
        {
            int nP2PMode = *((int*)msg) ;
            Log("MSG_TYPE_P2P_MODE: %d", nP2PMode);
        }
            break;
        default:
            break;
    }
}

JNIEXPORT void JNICALL Java_com_p2papi_jni_NativeCaller_Init(JNIEnv *env ,jobject obj)
{
    P2PAPI_Initial();

    P2PAPI_SetAVDataCallBack(_AVDataCallback, NULL);
    P2PAPI_SetMessageCallBack(_MessageCallback, NULL);   

    g_pAudioAdpcm = new CAdpcm();


    av_register_all();      

    g_pCodec = avcodec_find_decoder(CODEC_ID_H264);
    if(g_pCodec == NULL)
    {
        Log("pCodec == NULL\n");
        return ;
    }

    g_pCodecCtx = avcodec_alloc_context3(g_pCodec);
    if(g_pCodecCtx == NULL)
    {
        Log("if(pCodecCtx == NULL)\n");
        return ;
    }  
  
    //´ò¿ªcodec¡£Èç¹û´ò¿ª³É¹¦µÄ»°£¬·ÖÅäAVFrame£     
    if(avcodec_open2(g_pCodecCtx, g_pCodec, NULL) >= 0)     
    {     
        g_pFrame = avcodec_alloc_frame();   /* Allocate video frame   */
        
    }
    
}

JNIEXPORT void JNICALL Java_com_p2papi_jni_NativeCaller_Free(JNIEnv *env ,jobject obj)
{
   P2PAPI_DeInitial();
   SAFE_DELETE(g_pAudioAdpcm);

   if(g_pFrame)
    {
        av_free(g_pFrame);
        g_pFrame = NULL;
    }

    if(g_pCodecCtx)	
    {       
        avcodec_close(g_pCodecCtx);       
        g_pCodecCtx = NULL;   
    }
}

JNIEXPORT int JNICALL Java_com_p2papi_jni_NativeCaller_StartP2P(JNIEnv *env, jobject obj)
{
    if(ERROR_P2PAPI_OK != P2PAPI_CreateInstance(&g_lHandle))    
        return 0;    

    if(ERROR_P2PAPI_OK != P2PAPI_Connect(g_lHandle, (char*)"OBJ-000165-PBKMW", (char*)"admin", (char*)""))    
        return 0;
    
    return 1;
}

JNIEXPORT int JNICALL Java_com_p2papi_jni_NativeCaller_StopP2P(JNIEnv *env, jobject obj)
{
    P2PAPI_Close(g_lHandle);
    P2PAPI_DestroyInstance(g_lHandle); 
    
    return 1;
}

JNIEXPORT int JNICALL Java_com_p2papi_jni_NativeCaller_StartVideo(JNIEnv *env, jobject obj)
{
    if(ERROR_P2PAPI_OK != P2PAPI_StartVideo(g_lHandle))
    {
        return 0;
    }   
    
    return 1;
}

JNIEXPORT int JNICALL Java_com_p2papi_jni_NativeCaller_StopVideo(JNIEnv *env, jobject obj)
{
    if(ERROR_P2PAPI_OK != P2PAPI_StopVideo(g_lHandle))
    {
        return 0;
    }   
    
    return 1;
}

JNIEXPORT int JNICALL Java_com_p2papi_jni_NativeCaller_StartAudio(JNIEnv *env, jobject obj)
{
    if(ERROR_P2PAPI_OK != P2PAPI_StartAudio(g_lHandle))
    {
        return 0;
    }   
    
    return 1;
}

JNIEXPORT int JNICALL Java_com_p2papi_jni_NativeCaller_StopAudio(JNIEnv *env, jobject obj)
{
    if(ERROR_P2PAPI_OK != P2PAPI_StopAudio(g_lHandle))
    {
        return 0;
    }    
    
    return 1;
}

jint JNI_OnLoad(JavaVM* vm, void* reserved) 
{      
    JNIEnv* env = 0;    
    jint result = -1;   
    if (vm->GetEnv((void**) &env, JNI_VERSION_1_4) != JNI_OK)     
    {     
        goto bail;  
    }       

    result = JNI_VERSION_1_4;            

bail:  
    return result;
}
void JNI_OnUnload(JavaVM *vm, void *reserved)
{   
    
}


