   M S B A M L   `   `   `  ????  FindRoommate!    FindRoommate.View.LogInPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      >d2http://schemas.microsoft.com/expression/blend/2008    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5        N? Title$  	LogInPage??5      .??5
      ?  ? RowDefinitions 5   
   ?? 5      $??4* ?6   ?? 5      $
??1.5* ?6   ?? 5      $
??1.5* ?6   ?? 5      $
??1.5* ?6   ?? 5      ?? 5       ? ColumnDefinitions 5   
   ?? 5      $
??2.5* ?6   ?? 5      $
??1.5* ?6   ?? 5      $
??1.5* ?6   ?? 5      $
??1.5* ?6   ?? 5      .+?5   
   ?? $??/View/Images/Logo.PNG??6   $??1??5      $??2??5      $??10q?5      ?? 5   
   -   5         ??Name$ emailtxb??5      $??1??5"      $??1??5#      $??2??5$      $
??Left=?5%      $??Center=?5&      $??20(?5'      $??10q?5(      
?????w?$??Stretch=?5*      $??Stretch=?5+      ??5       ??    studentViewModel ?? Source# [   ?? Path$ StudentDataToLogIn.Email? ?? UpdateSourceTrigger$ PropertyChanged=?.??5+   .    ? 	Resources 5,       ?? 
TargetType	 ?? Property
 ?? Value??%^   '??       ?? 5-      " ??6   .?5.      ?? 	 ?@??CornerRadius$
 5??65   5/      50      .??6!   51      ?? 52   
   -   5        $ pwtxb??52      $??2??55      $??1??56      $??2??57      $
??Left=?58      $??Center=?59      $??Stretch=?5:      $??Stretch=?5;      $??20(?5=      
?????w?$??10q?5?      ??53      ?? # [  $! StudentDataToLogIn.Password?$ PropertyChanged=?.??5?       5@      ??%^   '??       ?? 5A      " ??6   .?5B      ?? 	 ?@??CornerRadius$
 5??65   5C      5D      .??6!   5E      ?? 5F   
   -   5         ??Name$ SignUpButton??5G      $??회원가입??5F      $??4??5I      $??1??5J      $??2??5K      $??Center=?5L      $	??100??5M      $??25??5N      
?????w?
???????
???????5Q      ?? 5S   
   -   5        $ LogInButton??5T      $??	로그인??5S      $??3??5U      $??2??5V      $??1??5W      $??Stretch=?5X      $??Stretch=?5Y      $??10q?5Z      $??20(?5[      $
??Bold"?5\      ???#13437e
?????????5_      ?? # [  $ LogInButtonCommand? 5a      ??%_   '??       ?? 5b      " ??6   .?5c      ?? 	 ?@??CornerRadius$
 10??65   5d      5e      5f      5g      5h      