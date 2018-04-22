using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryCleaner
{
    static class Extension
    {
        // 기본 확장자 - 문서, 이미지, 음성, 영상, 압축, 텍스트
        public static string defaultDocExtension = "csv,doc,dochtml,docm,docx,docxml,dot,dothtml,dotm,dotx,eps,fdf,key,keynote,kth,mpd,mpp,mpt,mpx,nmbtemplate,numbers,odc,odg,odp,ods,odt,pages,pdf,pdfxml,pot,pothtml,potm,potx,ppa,ppam,pps,ppsm,ppsx,ppt,ppthtml,pptm,pptx,pptxml,prn,ps,pwz,rtf,tab,template,tsv,txt,vdx,vsd,vss,vst,vsx,vtx,wbk,wiz,wpd,wps,xdf,xdp,xlam,xll,xlr,xls,xlsb,xlsm,xlsx,xltm,xltx,xps";
        public static string defaultImgExtension = "bmp,cr2,gif,ico,ithmb,jpeg,jpg,nef,png,raw,svg,tif,tiff,wbmp,webp";
        public static string defaultAudioExtension = "aac,aif,aifc,aiff,au,flac,m4a,m4b,m4p,m4r,mid,mp3,oga,ogg,opus,ra,ram,spx,wav,wma";
        public static string defaultVideoExtension = "3g2,3gp,3gpp,3gpp2,asf,avi,dv,dvi,flv,m2t,m4v,mkv,mov,mp4,mpeg,mpg,mts,ogv,ogx,rm,rmvb,ts,vob,webm,wmv";
        public static string defaultCompacExtension = "ace,alz,bz2,gz,jar,rar,tar,xz,zip, 7z";
        public static string defaultTxtExtension = "applescript,as,as3,c,cc,clisp,coffee,cpp,cs,css,csv,cxx,def,diff,erl,fountain,ft,h,hpp,htm,html,hxx,inc,ini,java,js,json,less,log,lua,m,markdown,mat,md,mdown,mkdn,mm,mustache,mxml,patch,php,phtml,pl,plist,properties,py,rb,sass,scss,sh,shtml,sql,tab,taskpaper,tex,text,tmpl,tsv,txt,url,vb,xhtml,xml,yaml,yml";
        public static string defaultDiscExtension = "bin,dmg,img,iso,lcd,ooo";
        public static string defaultEtcExtension;

        // 기타 확장자 - 사용자 추가 확장자
        public static string userEtcExtension;
        public static string userDocExtension;
        public static string userImgExtension;
        public static string userAudioExtension;
        public static string userVideoExtension;
        public static string userCompacExtension;
        public static string userTxtExtension;
        public static string userDiscExtension;

        // 확장자 조합
        public static string docExtension;
        public static string imgExtension;
        public static string audioExtension;
        public static string videoExtension;
        public static string compacExtension;
        public static string txtExtension;
        public static string discExtension;
        public static string etcExtension;

        // 배열로 만들기
        public static string[] arrDocExtension;
        public static string[] arrImgExtension;
        public static string[] arrAudioExtension;
        public static string[] arrVideoExtension;
        public static string[] arrCompacExtension;
        public static string[] arrTxtExtension;
        public static string[] arrDiscExtension;
        public static string[] arrEtcExtension;

        // 현재 확장자 - 초기 확장자 + 사용자 추가 확장자
        public static string initExtension = "";
        public static string userExtension = "";
        public static string curExtension = "";

        public static char sep = ',';

        public static void LoadExtension()
        {
            userEtcExtension = Properties.Settings.Default.EtcExtensionList;
            userDocExtension = Properties.Settings.Default.DocExtensionList;
            userImgExtension = Properties.Settings.Default.ImageExtensionList;
            userAudioExtension = Properties.Settings.Default.AudioExtensionList;
            userVideoExtension = Properties.Settings.Default.VideoExtensionList;
            userCompacExtension = Properties.Settings.Default.CompactExtensionLIst;
            userTxtExtension = Properties.Settings.Default.TxtExtensionList;
            userDiscExtension = Properties.Settings.Default.DiscExtensionList;

            etcExtension = defaultEtcExtension + userEtcExtension;
            docExtension = defaultDocExtension + userDocExtension;
            imgExtension = defaultImgExtension + userImgExtension;
            audioExtension = defaultAudioExtension + userAudioExtension;
            videoExtension = defaultVideoExtension + userVideoExtension;
            compacExtension = defaultCompacExtension + userCompacExtension;
            txtExtension = defaultTxtExtension + userTxtExtension;
            discExtension = defaultDiscExtension + userDiscExtension;


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
            if (Properties.Settings.Default.isDoc)
            {
                initExtension += docExtension;
                userExtension += userDocExtension;
            }
            if (Properties.Settings.Default.isImg)
            {
                initExtension += imgExtension;
                userExtension += userImgExtension;
            }
            if (Properties.Settings.Default.isVideo)
            {
                initExtension += videoExtension;
                userExtension += userVideoExtension;
            }
            if (Properties.Settings.Default.isTxt)
            {
                initExtension += txtExtension;
                userExtension += userTxtExtension;
            }
            if (Properties.Settings.Default.isDisc)
            {
                initExtension += discExtension;
                userExtension += userDiscExtension;
            }
            if (Properties.Settings.Default.isEtc)
            {
                userExtension += userEtcExtension;
            }
        }

        public static void TokenizeExtension()
        {
            arrDocExtension = docExtension.Split(sep);
        }

        public static bool CheckActivatedExtension()
        {
            return (Properties.Settings.Default.isAudio || Properties.Settings.Default.isCompac ||
                    Properties.Settings.Default.isDoc || Properties.Settings.Default.isEtc ||
                    Properties.Settings.Default.isImg || Properties.Settings.Default.isVideo ||
                    Properties.Settings.Default.isTxt || Properties.Settings.Default.isDisc);
        }
    }
}
