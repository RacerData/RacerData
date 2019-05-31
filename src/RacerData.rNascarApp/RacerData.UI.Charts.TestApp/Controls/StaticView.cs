using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rNascarApp.UI.Controls
{
    public partial class StaticView : UserControl
    {
        public StaticView()
        {
            InitializeComponent();

            webBrowser1.DocumentText = @"<html>
<head>
  <link href=""https://vjs.zencdn.net/7.5.4/video-js.css"" rel=""stylesheet"">

  < !--If you'd like to support IE8 (for Video.js versions prior to v7) -->
  < script src = ""https://vjs.zencdn.net/ie8/1.1.2/videojs-ie8.min.js"" ></ script >
 </ head >
 

 < body >
 < video id = ""live-video_html5_api"" class=""video-js"" width='1080' height='680' playsinline=""playsinline"" preload=""auto"" data-setup=""{}"" crossorigin=""anonymous"" muted=""muted"" tabindex=""-1"" src=""blob:https://www.nascar.com/802ddfe8-aef4-40b2-8b90-78c5c9dde641"">
      <source src = ""https://nascaruncovered.akamaized.net/hls/live/2004110/uncovered_practice/master.m3u8"" type=""application/x-mpegURL"" label=""1080p"">
	<p class='vjs-no-js'>
      To view this video please enable JavaScript, and consider upgrading to a web browser that
      <a href='https://videojs.com/html5-video-support/' target='_blank'> supports HTML5 video</a>
    </p>
  </video>
  <script src = 'https://vjs.zencdn.net/7.5.4/video.js' ></ script >
 </ body >
 </ html >";
        }
    }
}
