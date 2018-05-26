using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryCleaner
{
    public static class Extension
    {
        // 기본 확장자 - 문서, 이미지, 음성, 영상, 압축, 텍스트
        public static string defaultAudioExtension = "aac,aif,aifc,aiff,au,flac,m4a,m4b,m4p,m4r,mid,mp3,oga,ogg,opus,ra,ram,spx,wav,wma";
        public static string defaultCompacExtension = "ace,alz,bz2,gz,jar,rar,tar,xz,zip, 7z";
        public static string defaultDevelopeExtension = "cpp,c,hpp,h,java,jav";
        public static string defaultDocExtension = "csv,doc,dochtml,docm,docx,docxml,dot,dothtml,dotm,dotx,eps,fdf,key,keynote,kth,mpd,mpp,mpt,mpx,nmbtemplate,numbers,odc,odg,odp,ods,odt,pages,pdf,pdfxml,pot,pothtml,potm,potx,ppa,ppam,pps,ppsm,ppsx,ppt,ppthtml,pptm,pptx,pptxml,prn,ps,pwz,rtf,tab,template,tsv,txt,vdx,vsd,vss,vst,vsx,vtx,wbk,wiz,wpd,wps,xdf,xdp,xlam,xll,xlr,xls,xlsb,xlsm,xlsx,xltm,xltx,xps";
        public static string defaultDiscExtension = "bin,dmg,img,iso,lcd,ooo";
        public static string defaultImgExtension = "bmp,cr2,gif,ico,ithmb,jpeg,jpg,nef,png,raw,svg,tif,tiff,wbmp,webp";
        public static string defaultTxtExtension = "applescript,as,as3,c,cc,clisp,coffee,cpp,cs,css,csv,cxx,def,diff,erl,fountain,ft,h,hpp,htm,html,hxx,inc,ini,java,js,json,less,log,lua,m,markdown,mat,md,mdown,mkdn,mm,mustache,mxml,patch,php,phtml,pl,plist,properties,py,rb,sass,scss,sh,shtml,sql,tab,taskpaper,tex,text,tmpl,tsv,txt,url,vb,xhtml,xml,yaml,yml";
        public static string defaultVideoExtension = "3g2,3gp,3gpp,3gpp2,asf,avi,dv,dvi,flv,m2t,m4v,mkv,mov,mp4,mpeg,mpg,mts,ogv,ogx,rm,rmvb,ts,vob,webm,wmv";

        public static string defaultEtcExtension = null;

        // 기타 확장자 - 사용자 추가 확장자
        public static string userAudioExtension;
        public static string userCompacExtension;
        public static string userDevelopeExtension;
        public static string userDiscExtension;
        public static string userDocExtension;
        public static string userEtcExtension;
        public static string userImgExtension;
        public static string userTxtExtension;
        public static string userVideoExtension;

        // 확장자 조합
        public static string audioExtension;
        public static string compacExtension;
        public static string developeExtension;
        public static string discExtension;
        public static string docExtension;
        public static string etcExtension;
        public static string imgExtension;
        public static string txtExtension;
        public static string videoExtension;

        // 배열로 만들기
        public static string[] arrAudioExtension;
        public static string[] arrCompacExtension;
        public static string[] arrDevelopeExtension;
        public static string[] arrDiscExtension;
        public static string[] arrDocExtension;
        public static string[] arrEtcExtension;
        public static string[] arrImgExtension;
        public static string[] arrTxtExtension;
        public static string[] arrVideoExtension;

        // 현재 확장자 - 초기 확장자 + 사용자 추가 확장자
        public static string initExtension = "";
        public static string userExtension = "";
        public static string curExtension = "";

        public static char sep = ',';

        public enum ExtensionCode
        {
            Audio = 1,
            Compact,
            Develope,
            DiscImage,
            Document,
            Etc,
            Image,
            Text,
            Video
        };

        public static void LoadExtension()
        {
            userAudioExtension = Properties.Settings.Default.AudioExtensionList;
            userCompacExtension = Properties.Settings.Default.CompactExtensionLIst;
            userDevelopeExtension = Properties.Settings.Default.DevelopeExtensionList;
            userDiscExtension = Properties.Settings.Default.DiscExtensionList;
            userDocExtension = Properties.Settings.Default.DocExtensionList;
            userEtcExtension = Properties.Settings.Default.EtcExtensionList;
            userImgExtension = Properties.Settings.Default.ImageExtensionList;
            userTxtExtension = Properties.Settings.Default.TxtExtensionList;
            userVideoExtension = Properties.Settings.Default.VideoExtensionList;

            audioExtension = defaultAudioExtension + userAudioExtension;
            compacExtension = defaultCompacExtension + userCompacExtension;
            developeExtension = defaultDevelopeExtension + userDevelopeExtension;
            discExtension = defaultDiscExtension + userDiscExtension;
            docExtension = defaultDocExtension + userDocExtension;
            etcExtension = defaultEtcExtension + userEtcExtension;
            imgExtension = defaultImgExtension + userImgExtension;
            txtExtension = defaultTxtExtension + userTxtExtension;
            videoExtension = defaultVideoExtension + userVideoExtension;


            if (Properties.Settings.Default.isAudio)
            {
                initExtension += audioExtension;
                userExtension += userAudioExtension;
            }
            if (Properties.Settings.Default.isCompac)
            {
                initExtension += compacExtension;
                userExtension += userCompacExtension;
            }
            if (Properties.Settings.Default.isDevelope)
            {
                initExtension += developeExtension;
                userExtension += userDevelopeExtension;
            }
            if (Properties.Settings.Default.isDisc)
            {
                initExtension += discExtension;
                userExtension += userDiscExtension;
            }
            if (Properties.Settings.Default.isDoc)
            {
                initExtension += docExtension;
                userExtension += userDocExtension;
            }
            if (Properties.Settings.Default.isEtc)
            {
                userExtension += userEtcExtension;
            }
            if (Properties.Settings.Default.isImg)
            {
                initExtension += imgExtension;
                userExtension += userImgExtension;
            }
            if (Properties.Settings.Default.isTxt)
            {
                initExtension += txtExtension;
                userExtension += userTxtExtension;
            }
            if (Properties.Settings.Default.isVideo)
            {
                initExtension += videoExtension;
                userExtension += userVideoExtension;
            }
        }

        public static void TokenizeExtension()
        {
            arrAudioExtension = audioExtension.Split(sep);
            arrCompacExtension = compacExtension.Split(sep);
            arrDevelopeExtension = developeExtension.Split(sep);
            arrDiscExtension = discExtension.Split(sep);
            arrDocExtension = docExtension.Split(sep);
            arrEtcExtension = etcExtension.Split(sep);
            arrImgExtension = imgExtension.Split(sep);
            arrTxtExtension = txtExtension.Split(sep);
            arrVideoExtension = videoExtension.Split(sep);
        }

        public static bool CheckActivatedExtension()
        {
            return (Properties.Settings.Default.isAudio || Properties.Settings.Default.isCompac ||
                    Properties.Settings.Default.isDevelope || Properties.Settings.Default.isDoc ||
                    Properties.Settings.Default.isDisc || Properties.Settings.Default.isEtc ||
                    Properties.Settings.Default.isImg || Properties.Settings.Default.isTxt ||
                    Properties.Settings.Default.isVideo);
        }

        public static string CheckExtensionType(string extension)
        {
            int size;
            size = arrAudioExtension.Length;
            for (int i = 0; i < size; i++)
            {
                if (arrAudioExtension[i].Equals(extension))
                {
                    return "Audio";
                }
            }

            size = arrCompacExtension.Length;
            for (int i = 0; i < size; i++)
            {
                if (arrCompacExtension[i].Equals(extension))
                {
                    return "Compact";
                }
            }

            size = arrDevelopeExtension.Length;
            for (int i = 0; i < size; i++)
            {
                if (arrDevelopeExtension[i].Equals(extension))
                {
                    return "Develope";
                }
            }

            size = arrDiscExtension.Length;
            for (int i = 0; i < size; i++)
            {
                if (arrDiscExtension[i].Equals(extension))
                {
                    return "DiscImage";
                }
            }

            size = arrDocExtension.Length;
            for (int i = 0; i < size; i++)
            {
                if (arrDocExtension[i].Equals(extension))
                {
                    return "Document";
                }
            }

            size = arrEtcExtension.Length;
            for (int i = 0; i < size; i++)
            {
                if (arrEtcExtension[i].Equals(extension))
                {
                    return "Etc";
                }
            }


            size = arrImgExtension.Length;
            for (int i = 0; i < size; i++)
            {
                if (arrImgExtension[i].Equals(extension))
                {
                    return "Image";
                }
            }

            size = arrTxtExtension.Length;
            for (int i = 0; i < size; i++)
            {
                if (arrTxtExtension[i].Equals(extension))
                {
                    return "Text";
                }
            }

            size = arrVideoExtension.Length;
            for (int i = 0; i < size; i++)
            {
                if (arrVideoExtension[i].Equals(extension))
                {
                    return "Video";
                }
            }

            return "";
        }
    }
}
