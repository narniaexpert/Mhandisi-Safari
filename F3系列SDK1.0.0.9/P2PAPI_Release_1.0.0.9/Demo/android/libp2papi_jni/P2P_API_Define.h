
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
enable	0：禁止wifi功能；1：允许
ssid	欲加入wifi网络的ssid，长度 <= 40
channel	保留 =5
mode	Wifi模式
Authtype	0：禁止认证；1：wep；2：wpa tkip；3：wpa aes；4：wpa2 aes；5：wpa2 tkip+aes
encrypt	wep 校验方式，0：open；1：share
keyformat	wep密钥格式，0：16 进制数字；1：ascii 字符
defkey	wep中密钥选择：0-3
key1	wep密钥1，长度 <= 30
key2	wep密钥2
key3	wep密钥3
key4	wep密钥4
key1_bits	wep密钥1 长度，0：64 bits；1：128 bits
key2_bits	wep密钥2 长度，0：64 bits；1：128 bits
key3_bits	wep密钥3 长度，0：64 bits；1：128 bits
key4_bits	wep密钥4 长度，0：64 bits；1：128 bits
wpa_psk	wpa psk 密钥，长度 <= 64*/

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
now	从1970-1-1 0:0:0到指定时间所流逝的秒数，如附加该参数，设备则依据此时间进行校时
tz	时区设置：和标准格林威治时间偏离的秒数
ntp_enable	0：禁止ntp校时；1：允许
ntp_svr	ntp服务器，长度 <= 64*/
typedef struct tag_STRU_DATETIME_PARAMS
{
    int now;
    int tz;
    int ntp_enable;
    char ntp_svr[64];
}STRU_DATETIME_PARAMS,*PSTRU_DATETIME_PARAMS;


//MSG_TYPE_SET_DDNS
/*service	0：禁止ddns服务
1：花生壳(暂不支持)
2：DynDns.org(dyndns)
3：DynDns.org(statdns)
4：DynDns.org(custom)
5：保留
6：保留
7：保留
8：3322(dyndns)
9：3322(statdns)
10：9299
11：厂家自有
12：厂家自有
user	ddns用户，长度 <= 64
pwd	ddns密码，长度 <= 64
host	ddns域名，长度 <= 64
proxy_svr	代理服务器地址，长度 <= 64 
Ddns_mode	部份dns需要的模式
proxy_port	代理服务器端口*/
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
svr	ftp服务器地址，长度 <= 64
port	ftp服务器端口
user	ftp服务器登录用户，长度 <= 64
pwd	ftp服务器登录密码，长度 <= 64
dir	ftp服务器上的存储目录，长度 <= 64
mode	0：port模式；1：pasv模式
Filename	ftp文件名*/
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
/*svr	邮件服务器地址，长度 <= 64
sort	邮件服务端口
user	邮件服务器登录用户，长度 <= 64
ssl	表示支持ssl认证
pwd	邮件服务器登录密码，长度 <= 64
Sender	邮件的发送者，长度 <= 64
receiver1	邮件的接收者1，长度 <= 64
receiver2	邮件的接收者2，长度 <= 64
receiver3	邮件的接收者3，长度 <= 64
receiver4	邮件的接收者4，长度 <= 64
mail_inet_ip	邮件通知IP,0->表示不需要，1->表示需要*/

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
/*led_mode：0：模式1；1：模式2；2：关掉指示灯
ptz_center_onstart：=1，启动后居中
ptz_auto_patrol_interval：设置自动巡视间隔，0：不自动巡视
ptz_run_times：巡视圈数，0：无限大
ptz_patrol_rate：云台手动操作速度，0-10，0：最快
ptz_patrol_up_rate：向上自动巡航速度：0-10，0：最慢
ptz_patrol_down_rate：向下自动巡航速度：0-10，0：最慢
ptz_patrol_left_rate：向左自动巡航速度：0-10，0：最慢
ptz_patrol_right_rate：向右自动巡航速度：0-10，0：最慢
　　disable_preset：启用预置位，1：禁用预置位
  　　ptz_preset:：启用启动时调用预置位，0表示启动居中，1-16表示调用相对应的预置位
    但禁用预置位后，启动时不会强制调用预置位
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