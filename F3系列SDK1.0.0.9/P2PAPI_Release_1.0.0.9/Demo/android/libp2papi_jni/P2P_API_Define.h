
#ifndef _P2P_API_DEFINE_H_
#define _P2P_API_DEFINE_H_

typedef void (*AVDataCallback)(long nHandle, int bVideo, char *pData, int len, void *pParam);
typedef void (*MessageCallback)(long nHandle, int type, char *msg, int len, void *pParam);

typedef struct tag_AV_HEAD
{
	unsigned int   		startcode;	//  0xa815aa55
	unsigned char		type;		//  0->264 idr frame 1->264 p 3:MJPEG  6:audio					
	unsigned char  		streamid;	// 
	unsigned short 	    militime;	//  diff time
	unsigned int 		sectime;	//  diff time
	unsigned int    	frameno;	//  frameno
	unsigned int 		len;		//  data len	
	unsigned char		version;	// version
	unsigned char		sessid;		//ssid
	unsigned char		other[2];
	unsigned char		other1[8];
}AV_HEAD,*PAV_HEAD;

//Message type
#define MSG_TYPE_P2P_STATUS         0x0
#define MSG_TYPE_P2P_MODE           0x1
#define MSG_TYPE_GET_CAMERA_PARAMS  0x2
#define MSG_TYPE_DECODER_CONTROL    0x3
#define MSG_TYPE_GET_PARAMS         0x4
#define MSG_TYPE_SNAPSHOT           0x5
#define MSG_TYPE_CAMERA_CONTROL     0x6
#define MSG_TYPE_SET_NETWORK        0x7
#define MSG_TYPE_REBOOT_DEVICE      0x8
#define MSG_TYPE_RESTORE_FACTORY    0x9
#define MSG_TYPE_SET_USER           0xa
#define MSG_TYPE_SET_WIFI           0xb
#define MSG_TYPE_SET_DATETIME       0xc
#define MSG_TYPE_GET_STATUS         0xd
#define MSG_TYPE_GET_PTZ_PARAMS     0xe
#define MSG_TYPE_SET_DDNS           0xf
#define MSG_TYPE_SET_MAIL           0x10
#define MSG_TYPE_SET_FTP            0x11
#define MSG_TYPE_SET_ALARM          0x12
#define MSG_TYPE_SET_PTZ            0x13
#define MSG_TYPE_WIFI_SCAN          0x14
#define MSG_TYPE_GET_ALARM_LOG      0x15
#define MSG_TYPE_GET_RECORD         0x16
#define MSG_TYPE_GET_RECORD_FILE    0x17
#define MSG_TYPE_SET_PPPOE          0x18
#define MSG_TYPE_SET_UPNP           0x19
#define MSG_TYPE_DEL_RECORD_FILE    0x1a
#define MSG_TYPE_SET_MEDIA          0x1b
#define MSG_TYPE_SET_RECORD_SCH     0x1c
#define MSG_TYPE_CLEAR_ALARM_LOG    0x1d
#define MSG_TYPE_WIFI_PARAMS        0x1f
#define MSG_TYPE_MAIL_PARAMS        0x20
#define MSG_TYPE_FTP_PARAMS         0x21
#define MSG_TYPE_NETWORK_PARAMS     0x22
#define MSG_TYPE_USER_INFO          0x23
#define MSG_TYPE_DDNS_PARAMS        0x24
#define MSG_TYPE_DATETIME_PARAMS    0x25


//p2p status
#define P2P_STATUS_CONNECT_TIME_OUT         0x0
#define P2P_STATUS_INVALID_ID               0x1
#define P2P_STATUS_CONNECT_SUCCESS          0x2
#define P2P_STATUS_DISCONNECTED             0x3
#define P2P_STATUS_CONNECT_FAIlED           0x4
#define P2P_STATUS_CONNECTING               0x5
#define P2P_STATUS_DEVICE_NOT_ON_LINE       0x6
#define P2P_STATUS_INVALID_USER_PWD         0x7

//p2p mode
#define P2P_MODE_P2P_RELAY                  0x0
#define P2P_MODE_P2P_CONNECTED              0x1

//MSG_TYPE_GET_CAMERA_PARAMS
typedef struct tag_STRU_CAMERA_PARAMS
{
    int resolution;
    int brightness;
    int contrast;
    int hue;
    int saturation;
    int flip;
}STRU_CAMERA_PARAMS,*PSTRU_CAMERA_PARAMS;

//MSG_TYPE_CAMERA_CONTROL
typedef struct tag_STRU_CAMERA_CONTROL
{
    int param;
    int value;
}STRU_CAMERA_CONTROL,*PSTRU_CAMERA_CONTROL;

//MSG_TYPE_SET_NETWORK
typedef struct tag_STRU_NETWORK_PARAMS
{
    char ipaddr[64];
    char netmask[64];
    char gatway[64];
    char dns1[64];
    char dns2[64];
    int dhcp;
    int port;
    int rtspport;
}STRU_NETWORK_PARAMS,*PSTRU_NETWORK_PARAMS;

//MSG_TYPE_SET_USER
typedef struct tag_STRU_USER_INFO
{
    char user1[64];
    char pwd1[64];
    char user2[64];
    char pwd2[64];
    char user3[64];
    char pwd3[64];
}STRU_USER_INFO,*PSTRU_USER_INFO;

//MSG_TYPE_SET_WIFI
/*
enable	0����ֹwifi���ܣ�1������
ssid	������wifi�����ssid������ <= 40
channel	���� =5
mode	Wifiģʽ
Authtype	0����ֹ��֤��1��wep��2��wpa tkip��3��wpa aes��4��wpa2 aes��5��wpa2 tkip+aes
encrypt	wep У�鷽ʽ��0��open��1��share
keyformat	wep��Կ��ʽ��0��16 �������֣�1��ascii �ַ�
defkey	wep����Կѡ��0-3
key1	wep��Կ1������ <= 30
key2	wep��Կ2
key3	wep��Կ3
key4	wep��Կ4
key1_bits	wep��Կ1 ���ȣ�0��64 bits��1��128 bits
key2_bits	wep��Կ2 ���ȣ�0��64 bits��1��128 bits
key3_bits	wep��Կ3 ���ȣ�0��64 bits��1��128 bits
key4_bits	wep��Կ4 ���ȣ�0��64 bits��1��128 bits
wpa_psk	wpa psk ��Կ������ <= 64*/

typedef struct tag_STRU_WIFI_PARAMS
{
    int enable;
    char ssid[128];
    int channel;
    int mode;
    int authtype;
    int encrypt;
    int keyformat;
    int defkey;
    char key1[128];
    char key2[128];
    char key3[128];
    char key4[128];
    int key1_bits;
    int key2_bits;
    int key3_bits;
    int key4_bits;
    char wpa_psk[128];
}STRU_WIFI_PARAMS,*PSTRU_WIFI_PARAMS;

//MSG_TYPE_SET_DATETIME
/*
now	��1970-1-1 0:0:0��ָ��ʱ�������ŵ��������總�Ӹò������豸�����ݴ�ʱ�����Уʱ
tz	ʱ�����ã��ͱ�׼��������ʱ��ƫ�������
ntp_enable	0����ֹntpУʱ��1������
ntp_svr	ntp������������ <= 64*/
typedef struct tag_STRU_DATETIME_PARAMS
{
    int now;
    int tz;
    int ntp_enable;
    char ntp_svr[64];
}STRU_DATETIME_PARAMS,*PSTRU_DATETIME_PARAMS;


//MSG_TYPE_SET_DDNS
/*service	0����ֹddns����
1��������(�ݲ�֧��)
2��DynDns.org(dyndns)
3��DynDns.org(statdns)
4��DynDns.org(custom)
5������
6������
7������
8��3322(dyndns)
9��3322(statdns)
10��9299
11����������
12����������
user	ddns�û������� <= 64
pwd	ddns���룬���� <= 64
host	ddns���������� <= 64
proxy_svr	�����������ַ������ <= 64 
Ddns_mode	����dns��Ҫ��ģʽ
proxy_port	����������˿�*/
typedef struct tag_STRU_DDNS_PARAMS
{
    int service;
    char user[64];
    char pwd[64];
    char host[64];
    char proxy_svr[64];
    int ddns_mode;
    int proxy_port;
}STRU_DDNS_PARAMS,*PSTRU_DDNS_PARAMS;

//MSG_TYPE_SET_FTP
/*
svr	ftp��������ַ������ <= 64
port	ftp�������˿�
user	ftp��������¼�û������� <= 64
pwd	ftp��������¼���룬���� <= 64
dir	ftp�������ϵĴ洢Ŀ¼������ <= 64
mode	0��portģʽ��1��pasvģʽ
Filename	ftp�ļ���*/
typedef struct tag_STRU_FTP_PARAMS
{
    char svr_ftp[64];
    char user[64];
    char pwd[64];
    char dir[128];
    int port;
    int mode;
    int upload_interval;
}STRU_FTP_PARAMS,*PSTRU_FTP_PARAMS;

//MSG_TYPE_SET_MAIL
/*svr	�ʼ���������ַ������ <= 64
sort	�ʼ�����˿�
user	�ʼ���������¼�û������� <= 64
ssl	��ʾ֧��ssl��֤
pwd	�ʼ���������¼���룬���� <= 64
Sender	�ʼ��ķ����ߣ����� <= 64
receiver1	�ʼ��Ľ�����1������ <= 64
receiver2	�ʼ��Ľ�����2������ <= 64
receiver3	�ʼ��Ľ�����3������ <= 64
receiver4	�ʼ��Ľ�����4������ <= 64
mail_inet_ip	�ʼ�֪ͨIP,0->��ʾ����Ҫ��1->��ʾ��Ҫ*/

typedef struct tag_STRU_MAIL_PARAMS
{
    char svr[64];    
    char user[64];    
    char pwd[64];
    char sender[64];
    char receiver1[64];
    char receiver2[64];
    char receiver3[64];
    char receiver4[64];
    int port;
    int ssl;
}STRU_MAIL_PARAMS,*PSTRU_MAIL_PARAMS;

//MSG_TYPE_SET_ALARM
/*motion_armed
motion_sensitivity
input_armed
ioin_level
iolinkage
alarmpresetsit
ioout_level
mail
snapshot
record
upload_interval
schedule_enable
schedule_sun_0
schedule_sun_1
schedule_sun_2
schedule_mon_0
schedule_mon_1
schedule_mon_2
schedule_tue_0
schedule_tue_1
schedule_tue_2
schedule_wed_0
schedule_wed_1
schedule_wed_2
schedule_thu_0
schedule_thu_1
schedule_thu_2
schedule_fri_0
schedule_fri_1
schedule_fri_2
schedule_sat_0
schedule_sat_1
schedule_sat_2*/

typedef struct tag_STRU_ALARM_PARAMS
{
    int motion_armed;
    int motion_sensitivity;
    int input_armed;
    int ioin_level;
    int iolinkage;
    int alarmpresetsit;
    int mail;
    int snapshot;
    int record;
    int upload_interval;
    int schedule_enable;
    int schedule_sun_0;
    int schedule_sun_1;
    int schedule_sun_2;
    int schedule_mon_0;
    int schedule_mon_1;
    int schedule_mon_2;
    int schedule_tue_0;
    int schedule_tue_1;
    int schedule_tue_2;
    int schedule_wed_0;
    int schedule_wed_1;
    int schedule_wed_2;
    int schedule_thu_0;
    int schedule_thu_1;
    int schedule_thu_2;
    int schedule_fri_0;
    int schedule_fri_1;
    int schedule_fri_2;
    int schedule_sat_0;
    int schedule_sat_1;
    int schedule_sat_2;
}STRU_ALARM_PARAMS,*PSTRU_ALARM_PARAMS;

//MSG_TYPE_SET_PTZ
/*led_mode��0��ģʽ1��1��ģʽ2��2���ص�ָʾ��
ptz_center_onstart��=1�����������
ptz_auto_patrol_interval�������Զ�Ѳ�Ӽ����0�����Զ�Ѳ��
ptz_run_times��Ѳ��Ȧ����0�����޴�
ptz_patrol_rate����̨�ֶ������ٶȣ�0-10��0�����
ptz_patrol_up_rate�������Զ�Ѳ���ٶȣ�0-10��0������
ptz_patrol_down_rate�������Զ�Ѳ���ٶȣ�0-10��0������
ptz_patrol_left_rate�������Զ�Ѳ���ٶȣ�0-10��0������
ptz_patrol_right_rate�������Զ�Ѳ���ٶȣ�0-10��0������
����disable_preset������Ԥ��λ��1������Ԥ��λ
  ����ptz_preset:����������ʱ����Ԥ��λ��0��ʾ�������У�1-16��ʾ�������Ӧ��Ԥ��λ
    ������Ԥ��λ������ʱ����ǿ�Ƶ���Ԥ��λ
    */
typedef struct tag_STRU_PTZ_PARAMS
{
    int led_mode;
    int ptz_center_onstart;
    int ptz_auto_patrol_interval;
    int ptz_run_times;
    int ptz_patrol_rate;
    int ptz_patrol_up_rate;
    int ptz_patrol_down_rate;
    int ptz_patrol_left_rate;
    int ptz_patrol_right_rate;
    int disable_preset;
    int ptz_preset;
}STRU_PTZ_PARAMS,*PSTRU_PTZ_PARAMS;

typedef struct tag_STRU_WIFI_SEARCH_RESULT
{
    char ssid[64];
    char mac[64];
    int security;
    char dbm0[32];
    char  dbm1[32];
    int mode;

}STRU_WIFI_SEARCH_RESULT,*PSTRU_WIFI_SEARCH_RESULT;

typedef struct tag_STRU_WIFI_SEARCH_RESULT_LIST
{
    int nResultCount;
    STRU_WIFI_SEARCH_RESULT wifi[100];
}STRU_WIFI_SEARCH_RESULT_LIST,*PSTRU_WIFI_SEARCH_RESULT_LIST;


#endif