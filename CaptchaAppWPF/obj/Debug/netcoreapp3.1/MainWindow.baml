   M S B A M L   `   `   `  ????H  DCaptchaAppWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:CaptchaAppWPFCaptchaAppWPF  5   	       CaptchaAppWPF.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:CaptchaAppWPF     5   	     ? Title$  
MainWindow??5   	   $	??450??6   $	??800??6)   .??5	      ?  ? RowDefinitions 5
   
   ?? 5      $??* ?6   ?? 5      $
??auto ?6   ?? 5      $
??auto ?6   .+?5   
   ?? -   5        $??2??5      $
??Open??6   $	??100??6-   5      ?? 5   
   -   5         ??Name$ 
Status_Box??5      $??Choose Image??5      $??20(?6(   $??1??66   
???   ?$??5q?5      $??Center=?5      ? 5   
    ? ColumnDefinitions 5      ?? 5      $??* ?6#   ?? 5      $??* ?6#   .+?5      ?? -   5         ??Name$ Original_Image??5      ?? 5      -   5        $ Recognized_Image??5      $??1??6.   5      5      5      