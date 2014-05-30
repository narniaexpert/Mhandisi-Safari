## Host system
HOST = linux-x86

## Android root directory
ANDROID_BASE = /opt/droid

ANDROID_NDK_BASE = /opt/android-ndk-r7b

## Android lib directory
ANDROID_LIBPATH = $(ANDROID_BASE)/lib


ANDROID_INCLUDES = \
	-I$(ANDROID_BASE)/dalvik/libnativehelper/include \
	-I$(ANDROID_BASE)/frameworks/base/include \
	-I$(ANDROID_BASE)/frameworks/base/include/media/stagefright/openmax \
	-I$(ANDROID_BASE)/frameworks/base/media/libstagefright/include \
	-I$(ANDROID_BASE)/hardware/libhardware/include \
	-I$(ANDROID_BASE)/system/core/include \
	-I/home/libp2papi_jni/ffmpeginclude

ANDROID = android-9

# pthreads forced define for inline stuff from threads.h
CFLAGS_EXTRA += -Werror -Wall -Wno-multichar -DHAVE_PTHREADS -DLOG_MASK=0x0f -DENABLE_DEBUG 

ANDROID_TOOL_PREFIX = $(ANDROID_NDK_BASE)/toolchains/arm-linux-androideabi-4.4.3/prebuilt/$(HOST)/bin/arm-linux-androideabi-

ANDROID_CFLAGS = -msoft-float -fpic -mthumb-interwork \
	-funwind-tables -fstack-protector -fno-short-enums \
	-fno-exceptions -fno-rtti \
	-DANDROID -O0 -g -fno-omit-frame-pointer \
	$(CFLAGS_EXTRA) \
	-I$(ANDROID_NDK_BASE)/platforms/$(ANDROID)/arch-arm/usr/include/ \
	-I$(ANDROID_NDK_BASE)/sources/cxx-stl/gnu-libstdc++/include \
	-I$(ANDROID_NDK_BASE)/sources/cxx-stl/gnu-libstdc++/libs/armeabi/include \
	$(ANDROID_INCLUDES) 

# Android link flags 
ANDROID_LDFLAGS = -shared -nostdlib --no-undefined -Bsymbolic  -L$(ANDROID_LIBPATH) 


ANDROID_LIBS = -L$(ANDROID_NDK_BASE)/platforms/$(ANDROID)/arch-arm/usr/lib \
	-lc -lstdc++ -lm -llog \
	./libffmpeg.so ./libP2PAPI.a \
	$(ANDROID_NDK_BASE)/toolchains/arm-linux-androideabi-4.4.3/prebuilt/$(HOST)/lib/gcc/arm-linux-androideabi/4.4.3/libgcc.a \
	 -g -lutils -lnativehelper 
 
libp2papi_jni.so: p2papi_jni.o Adpcm.o
	$(ANDROID_TOOL_PREFIX)ld $(ANDROID_LDFLAGS) -o libp2papi_jni.so p2papi_jni.o Adpcm.o $(ANDROID_LIBS) 


p2papi_jni.o: p2papi_jni.cpp 
	$(ANDROID_TOOL_PREFIX)g++ $(ANDROID_CFLAGS) -c p2papi_jni.cpp -o p2papi_jni.o
	
Adpcm.o: Adpcm.cpp 
	$(ANDROID_TOOL_PREFIX)g++ $(ANDROID_CFLAGS) -c Adpcm.cpp -o Adpcm.o
	

# Clean by deleting all the objs and the lib
clean:
	rm -fr *.o libp2papi_jni.so
