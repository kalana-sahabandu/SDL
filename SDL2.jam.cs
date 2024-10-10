using System;
using System.Linq;
using NiceIO;
using Bee.Core;
using Bee.NativeProgramSupport;
using Bee.Stevedore;
using static Bee.NativeProgramSupport.NativeProgramConfiguration;
#if PLATFORM_IN_SOURCESTREE_EMBEDDEDLINUX
using static Bee.NativeProgramSupport.EmbeddedLinuxNativeProgramConfigurationExtensions;
#endif
#if PLATFORM_IN_SOURCESTREE_QNX
using static Bee.NativeProgramSupport.QNXNativeProgramConfigurationExtensions;
#endif
using Unity.BuildSystem;

namespace External.SDL2
{
    static class SDL2
    {
        public static readonly Lazy<NativeProgram> Library = new Lazy<NativeProgram>(() =>
        {
            var result = new NativeProgram("SDL2");

            result.Defines.Add("HAVE_CONFIG_H", "_GNU_SOURCE");

            var root = new NPath("External/SDL2/");
            var src = new[]
            {
                "src/SDL_list.c",
                "src/atomic/SDL_atomic.c",
                "src/atomic/SDL_spinlock.c",
                "src/audio/SDL_audio.c",
                "src/audio/SDL_audiocvt.c",
                "src/audio/SDL_audiodev.c",
                "src/audio/SDL_audiotypecvt.c",
                "src/audio/SDL_mixer.c",
                "src/audio/SDL_wave.c",
                "src/audio/dummy/SDL_dummyaudio.c",
                "src/core/unix/SDL_poll.c",
                "src/cpuinfo/SDL_cpuinfo.c",
                "src/dynapi/SDL_dynapi.c",
                "src/events/SDL_clipboardevents.c",
                "src/events/SDL_displayevents.c",
                "src/events/SDL_dropevents.c",
                "src/events/SDL_events.c",
                "src/events/SDL_gesture.c",
                "src/events/SDL_keyboard.c",
                "src/events/SDL_mouse.c",
                "src/events/SDL_quit.c",
                "src/events/SDL_touch.c",
                "src/events/SDL_windowevents.c",
                "src/file/SDL_rwops.c",
                "src/filesystem/dummy/SDL_sysfilesystem.c",
                "src/haptic/dummy/SDL_syshaptic.c",
                "src/haptic/SDL_haptic.c",
                "src/hidapi/libusb/hid.c",
                "src/hidapi/SDL_hidapi.c",
                "src/joystick/dummy/SDL_sysjoystick.c",
                "src/joystick/hidapi/SDL_hidapi_gamecube.c",
                "src/joystick/hidapi/SDL_hidapijoystick.c",
                "src/joystick/hidapi/SDL_hidapi_ps4.c",
                "src/joystick/hidapi/SDL_hidapi_rumble.c",
                "src/joystick/hidapi/SDL_hidapi_steam.c",
                "src/joystick/hidapi/SDL_hidapi_switch.c",
                "src/joystick/hidapi/SDL_hidapi_xbox360.c",
                "src/joystick/hidapi/SDL_hidapi_xbox360w.c",
                "src/joystick/hidapi/SDL_hidapi_xboxone.c",
                "src/joystick/SDL_gamecontroller.c",
                "src/joystick/SDL_joystick.c",
                "src/joystick/steam/SDL_steamcontroller.c",
                "src/libm/e_atan2.c",
                "src/libm/e_exp.c",
                "src/libm/e_fmod.c",
                "src/libm/e_log10.c",
                "src/libm/e_log.c",
                "src/libm/e_pow.c",
                "src/libm/e_rem_pio2.c",
                "src/libm/e_sqrt.c",
                "src/libm/k_cos.c",
                "src/libm/k_rem_pio2.c",
                "src/libm/k_sin.c",
                "src/libm/k_tan.c",
                "src/libm/s_atan.c",
                "src/libm/s_copysign.c",
                "src/libm/s_cos.c",
                "src/libm/s_fabs.c",
                "src/libm/s_floor.c",
                "src/libm/s_scalbn.c",
                "src/libm/s_sin.c",
                "src/libm/s_tan.c",
                "src/loadso/dlopen/SDL_sysloadso.c",
                "src/loadso/dummy/SDL_sysloadso.c",
                "src/locale/SDL_locale.c",
                "src/locale/unix/SDL_syslocale.c",
                "src/main/dummy/SDL_dummy_main.c",
                "src/misc/SDL_url.c",
                "src/misc/unix/SDL_sysurl.c",
                "src/power/SDL_power.c",
                "src/render/opengles2/SDL_render_gles2.c",
                "src/render/opengles2/SDL_shaders_gles2.c",
                "src/render/opengles/SDL_render_gles.c",
                "src/render/opengl/SDL_render_gl.c",
                "src/render/opengl/SDL_shaders_gl.c",
                "src/render/SDL_d3dmath.c",
                "src/render/SDL_render.c",
                "src/render/SDL_yuv_mmx.c",
                "src/render/SDL_yuv_sw.c",
                "src/render/software/SDL_blendfillrect.c",
                "src/render/software/SDL_blendline.c",
                "src/render/software/SDL_blendpoint.c",
                "src/render/software/SDL_drawline.c",
                "src/render/software/SDL_drawpoint.c",
                "src/render/software/SDL_render_sw.c",
                "src/render/software/SDL_rotate.c",
                "src/render/software/SDL_triangle.c",
                "src/SDL_assert.c",
                "src/SDL.c",
                "src/SDL_dataqueue.c",
                "src/SDL_error.c",
                "src/SDL_hints.c",
                "src/SDL_log.c",
                "src/sensor/dummy/SDL_dummysensor.c",
                "src/sensor/SDL_sensor.c",
                "src/stdlib/SDL_crc32.c",
                "src/stdlib/SDL_getenv.c",
                "src/stdlib/SDL_iconv.c",
                "src/stdlib/SDL_malloc.c",
                "src/stdlib/SDL_qsort.c",
                "src/stdlib/SDL_stdlib.c",
                "src/stdlib/SDL_string.c",
                "src/stdlib/SDL_strtokr.c",
                "src/thread/pthread/SDL_syscond.c",
                "src/thread/pthread/SDL_sysmutex.c",
                "src/thread/pthread/SDL_syssem.c",
                "src/thread/pthread/SDL_systhread.c",
                "src/thread/pthread/SDL_systls.c",
                "src/thread/SDL_thread.c",
                "src/timer/dummy/SDL_systimer.c",
                "src/timer/SDL_timer.c",
                "src/timer/unix/SDL_systimer.c",
                "src/video/dummy/SDL_nullevents.c",
                "src/video/dummy/SDL_nullframebuffer.c",
                "src/video/dummy/SDL_nullvideo.c",
                "src/video/offscreen/SDL_offscreenevents.c",
                "src/video/offscreen/SDL_offscreenframebuffer.c",
                "src/video/offscreen/SDL_offscreenopengl.c",
                "src/video/offscreen/SDL_offscreenvideo.c",
                "src/video/offscreen/SDL_offscreenwindow.c",
                "src/video/SDL_blit_0.c",
                "src/video/SDL_blit_1.c",
                "src/video/SDL_blit_A.c",
                "src/video/SDL_blit_auto.c",
                "src/video/SDL_blit.c",
                "src/video/SDL_blit_copy.c",
                "src/video/SDL_blit_N.c",
                "src/video/SDL_blit_slow.c",
                "src/video/SDL_bmp.c",
                "src/video/SDL_clipboard.c",
                "src/video/SDL_egl.c",
                "src/video/SDL_fillrect.c",
                "src/video/SDL_pixels.c",
                "src/video/SDL_rect.c",
                "src/video/SDL_RLEaccel.c",
                "src/video/SDL_shape.c",
                "src/video/SDL_stretch.c",
                "src/video/SDL_surface.c",
                "src/video/SDL_video.c",
                "src/video/SDL_vulkan_utils.c",
                "src/video/SDL_yuv.c",
                "src/video/yuv2rgb/yuv_rgb.c",
            };
            result.Sources.Add(src.Select(p => root.Combine(p)));

            var linuxSrc = new[]
            {
                "src/audio/openslES/SDL_openslES.c",
                "src/core/linux/SDL_dbus.c",
                "src/core/linux/SDL_evdev.c",
                "src/core/linux/SDL_evdev_capabilities.c",
                "src/core/linux/SDL_evdev_kbd.c",
                "src/core/linux/SDL_ibus.c",
                "src/core/linux/SDL_ime.c",
                "src/core/linux/SDL_threadprio.c",
                "src/core/linux/SDL_udev.c",
                "src/filesystem/unix/SDL_sysfilesystem.c",
                "src/haptic/linux/SDL_syshaptic.c",
                "src/hidapi/linux/hid.c",
                "src/joystick/linux/SDL_sysjoystick.c",
                "src/power/linux/SDL_syspower.c",
                "src/video/wayland/SDL_waylandclipboard.c",
                "src/video/wayland/SDL_waylanddatamanager.c",
                "src/video/wayland/SDL_waylanddyn.c",
                "src/video/wayland/SDL_waylandevents.c",
                "src/video/wayland/SDL_waylandmouse.c",
                "src/video/wayland/SDL_waylandopengles.c",
                "src/video/wayland/SDL_waylandtouch.c",
                "src/video/wayland/SDL_waylandvideo.c",
                "src/video/wayland/SDL_waylandvulkan.c",
                "src/video/wayland/SDL_waylandwindow.c",
                "src/video/wayland/SDL_waylandmessagebox.c",
                "src/video/wayland/SDL_waylandkeyboard.c",
                "src/video/x11/edid-parse.c",
                "src/events/imKStoUCS.c",
                "src/video/x11/SDL_x11clipboard.c",
                "src/video/x11/SDL_x11dyn.c",
                "src/video/x11/SDL_x11events.c",
                "src/video/x11/SDL_x11framebuffer.c",
                "src/video/x11/SDL_x11keyboard.c",
                "src/video/x11/SDL_x11messagebox.c",
                "src/video/x11/SDL_x11modes.c",
                "src/video/x11/SDL_x11mouse.c",
                "src/video/x11/SDL_x11opengl.c",
                "src/video/x11/SDL_x11opengles.c",
                "src/video/x11/SDL_x11shape.c",
                "src/video/x11/SDL_x11touch.c",
                "src/video/x11/SDL_x11video.c",
                "src/video/x11/SDL_x11vulkan.c",
                "src/video/x11/SDL_x11window.c",
                "src/video/x11/SDL_x11xinput2.c",
                "src/video/x11/SDL_x11xfixes.c",
                "src/pointer-constraints-unstable-v1-protocol.c",
                "src/relative-pointer-unstable-v1-protocol.c",
                "src/wayland-protocol.c",
                "src/xdg-decoration-unstable-v1-protocol.c",
                "src/xdg-shell-protocol.c",
                "src/idle-inhibit-unstable-v1-protocol.c",
                "src/text-input-unstable-v3-protocol.c",
                "src/keyboard-shortcuts-inhibit-unstable-v1-protocol.c",
                "src/xdg-activation-v1-protocol.c",
                "src/tablet-unstable-v2-protocol.c",
                "src/xdg-output-unstable-v1-protocol.c",
                "src/viewporter-protocol.c",
            };
            result.Sources.Add(IsLinux, linuxSrc.Select(p => root.Combine(p)));
            result.Sources.Add(IsLinux, root.Combine("src/core/linux/SDL_fcitx.c"));

#if PLATFORM_IN_SOURCESTREE_EMBEDDEDLINUX
            var embeddedSrc = new[]
            {
                "src/ivi-application-client-protocol.c",
                "src/webos-shell-client-protocol.c",
            };
            result.Sources.Add(IsEmbeddedLinux, linuxSrc.Select(p => root.Combine(p)));
            result.Sources.Add(IsEmbeddedLinux, embeddedSrc.Select(p => root.Combine(p)));
#endif

#if PLATFORM_IN_SOURCESTREE_QNX
            var qnxsrc = new[]
            {
                "src/audio/openslES/SDL_openslES.c",
                "src/video/qnx/SDL_qnxevents.c",
                "src/video/qnx/SDL_qnxgles.c",
                "src/video/qnx/SDL_qnxkeyboard.c",
                "src/video/qnx/SDL_qnxkeymap.c",
                "src/video/qnx/SDL_qnxmouse.c",
                "src/video/qnx/SDL_qnxtouch.c",
                "src/video/qnx/SDL_qnxvideo.c",
                "src/video/qnx/SDL_qnxwindow.c",
                "src/filesystem/unix/SDL_sysfilesystem.c",
            };
            result.Sources.Add(IsQNX, qnxsrc.Select(p => root.Combine(p)));
#endif

            var macSrc = new[]
            {
                "src/audio/coreaudio/SDL_coreaudio.m",
                "src/file/cocoa/SDL_rwopsbundlesupport.m",
                "src/filesystem/cocoa/SDL_sysfilesystem.m",
                "src/haptic/darwin/SDL_syshaptic.c",
                "src/hidapi/mac/hid.c",
                "src/joystick/darwin/SDL_iokitjoystick.c",
                "src/joystick/iphoneos/SDL_mfijoystick.m",
                "src/power/macosx/SDL_syspower.c",
                "src/video/cocoa/SDL_cocoaclipboard.m",
                "src/video/cocoa/SDL_cocoaevents.m",
                "src/video/cocoa/SDL_cocoakeyboard.m",
                "src/video/cocoa/SDL_cocoamodes.m",
                "src/video/cocoa/SDL_cocoamouse.m",
                "src/video/cocoa/SDL_cocoamousetap.m",
                "src/video/cocoa/SDL_cocoashape.m",
                "src/video/cocoa/SDL_cocoamessagebox.m",
                "src/video/cocoa/SDL_cocoavideo.m",
                "src/video/cocoa/SDL_cocoawindow.m"
            };
            result.Sources.Add(IsMac, macSrc.Select(p => root.Combine(p)));

            result.IncludeDirectories.Add($"{root}/include");
            result.IncludeDirectories.Add(IsLinux, c => new NPath[]
            {
                $"{root}/include/linux{c.ToolChain.Architecture.Bits}",
                "=/usr/include/dbus-1.0",
                "=/usr/lib64/dbus-1.0/include",

            });

#if PLATFORM_IN_SOURCESTREE_EMBEDDEDLINUX
            result.IncludeDirectories.Add(IsEmbeddedLinux, c => new NPath[]
            {
                $"{root}/include/embeddedlinux_{c.ToolChain.Architecture.DisplayName}",
            });
            result.Defines.Add(c => IsEmbeddedLinux(c) && ((UnityPlayerConfiguration)c).DevelopmentPlayer,
                "ENABLE_UNITY_DIAGNOSTICS"
            );
#endif

#if PLATFORM_IN_SOURCESTREE_QNX
            result.IncludeDirectories.Add(IsQNX, c => new NPath[]
            {
                $"{root}/include/qnx_{c.ToolChain.Architecture.DisplayName}",
            });
            result.Defines.Add(c => IsQNX(c) && ((UnityPlayerConfiguration)c).DevelopmentPlayer,
                "ENABLE_UNITY_DIAGNOSTICS"
            );
#endif

            result.IncludeDirectories.Add(c => IsMac(c) && c.ToolChain.Architecture is x64Architecture, c => new NPath[]
            {
                $"{root}/include/mac_x64",
            });

            // optimize for size in release
            result.CompilerSettings().Add(c => c.CodeGen != CodeGen.Debug, c => c.WithOptimizationLevel(OptimizationLevel.Size));

            return result;
        });
    }
}
