   M S B A M L   `   `   `  ����B  >DenTool, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:DenToolDenTool  5   	       DenTool.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:DenTool     5   	   $	��280��5   	   $	��400��5	   	   $	��280��5
   	   $	��400��5   	      DenTool  � Title#  �   5   	    � WindowStartupLocation$ CenterScreen=�5   	   .��5      � .+�5   
   ]� .+�5      o� .@�5      m�   File#���  6   .@�5      m� -   5          Open#���  5      6?   m� 5      -   5          Exit#���  5      6?   5      m� 5        Language#���  6   .@�5      m� -   5         m�Name$ English��5        English#���  5      5      m� 5      -   5        $ 	Hungarian��5        	Hungarian#���  5      5      5      5      5      �� 5    
   $��Center=�6   $��Center=�5!      .+�5"      �� -   5         ��Name$ GroupBoxSQL��5"      
���   �$	��350��5$      $��10q�5%      ��5&      �� 5'      $��14(�6     SQL_Settings#���  5(      .��5*      �  � ColumnDefinitions 5+      �� 5,      $��* �6+   �� 5-      $��2* �6+    � RowDefinitions 5/      �� 50      $��* �6(   �� 51      $��* �6(   �� 52      $��* �6(   �� 53      $��* �6(   .+�57      �� -   5         ��Name$ LabelServer��57       
 Server#���  58      $��0��59      �� 5:      -   5         ��Name$ TextBoxServer��5:      $	��200��5;      $��20��5<      $��1��5=      $��0��5>      $
��Left=�5?      �� 5A      -   5        $ LabelDatabase��5A       	 Database#��� 	 5B      $��0��5C      $��1��5D      �� 5E      -	   5        $ TextBoxDatabase��5E      $
��Left=�5F      $	��200��5G      $��20��5H      $��1��5I      $��1��5J      �� 5L      -
   5        $ LabelUsername��5L       
 Username#��� 
 5M      $��0��5N      $��2��5O      �� 5P      -   5        $ TextBoxUsername��5P      $
��Left=�5Q      $	��200��5R      $��20��5S      $��1��5T      $��2��5U      �� 5W      -   5        $ LabelPassword��5W        Password#���  5X      $��0��5Y      $��3��5Z      G� 5[      -   5         G�Name$ PasswordBox��5[   "   $
��Left=�5\   "   $	��200��5]   "   $��20��5^   "   $��1��5_   "   $��3��5`   "   5a      5b      �� 5e      	 �� Orientation$	 
Horizontal=�6   $
��10,0q�5f      .+�5g      �� -   5        
 ��Name$
 ImageAlertExe��5g   !     TestCoveredPassing_16x#��[ 5h   !   $y�	Collapsed=�5i   !   �� 5j      -   5         ��Name$ TextBlockLoaded��5j       
 Loaded#���  5k      $
��Wrap=�5l      5m      �� 5n      $	 
Horizontal=�6   $
��10,0q�5o      .+�5q      �� -   5        $
 
ImageAlert��5q   !   #��[ 5r   !   $y�	Collapsed=�5s   !   �� 5t      -   5        $ TextBlockResult��5t        SettingsDefault#���  5u      $
��Wrap=�5v      5w      ]� 5y      $��10,10q�6   .+�5z      �� -   5        $
��Left=�5z        Test#���  5{      $	��100��5|      $��23��5}      5~      �� 5      -   5         ��Name$ 
ButtonSave��5      $��Right=�5�        Save#���  5�      $	��100��5�      $��23��5�      {�.  5�      5�      5�      5�      5�      