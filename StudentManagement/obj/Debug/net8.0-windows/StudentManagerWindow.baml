   M S B A M L   `   `   `  ����L  HStudentManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:StudentManagementStudentManagement  5   	   ,    &StudentManagement.StudentManagerWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:StudentManagement     5   	     � Title$  Student Manager��5   
   $	��600��6"   $	��950��6/    � WindowStartupLocation$ CenterScreen=�5	   	   .��5      ]� ���#F0F2F5.+�5   
   ]� $	��Top=�6   ���	#FF0C99DD$��50��6@   .+�5      �� -   5         ��Name$ 
txtWelcome��5      $��Hi, Teacher��6(   $��16(�6>   
�������$��Center=�5      $
��10,0q�6/   �� 5      -   5        $��Logout��5      $��80��6&   $��0,0,10,0q�61   $��Right=�5      $��Center=�61   6L   5      � 5   
   $��10q�6   ��5      �� 5       �� 
StartPoint$	 0,0&�6&    �� EndPoint$	 1,1&�67   .��5      �  � Color$ 	#FF2FBBFF��6#    � Offset$	 0.0Q�65   � 5      $ 	#FF0E2337��6#   $	 1.0Q�65   5       � RowDefinitions 5      �� 5      $
��Auto �6    �� 5       $��* �6    .+�5$      ��  �� Orientation$ 
Horizontal=�6   $��5q�62   $��0��6=   .+�5%      �� $��Name:��6   $��Center=�6(   �� 5&      -   5        	 ��Name$	 txtSearchName��5&      $	��180��61   $��5q�6=   �� 5'      $��Student ID:��6   $��Center=�6.   $��10,0,0,0q�6I   �� 5(      -   5        $	 txtSearchID��5(      $	��180��6/   $��5q�6;   �� 5)      -   5        
 ��Name$
 	btnSearch��5)      $��Search��6,   $��80��6=   $��10,0,0,0q�6H   6Z   5*      � 5-      $��1��6   $��5,10,5,5q�6     � ColumnDefinitions 5.      �� 5/      $��* �6'   �� 50      $	��300 �6'   .+�54      �� $��0��6   $��5q�6-   .@�56      �� $��Manage Students��6   .��57      � $��10q�6   .+�58      �� $��Add Student��6%   $	��100��6;   $��30��6G   $
��Left=�6S   $	��Top=�6n   $��10q�6�   �� 59      $��View Student Detail��6%   $	��110��6C   $��30��6O   $
��Left=�6[   $	��Top=�6v   $��
120,10,0,0q�6�   �� 5:      $��Delete Student��6%   $	��110��6>   $��30��6J   $
��Left=�6V   $	��Top=�6q   $��
251,10,0,0q�6�   &   System.Windows.Controls.DataGrid  5<      -   5          Name$ 
dgStudents��5<   '      AutoGenerateColumns$ False��6;   $��10,50,10,10q�6W      CanUserAddRows$ False��5=   V      Columns 5>   "   0  *System.Windows.Controls.DataGridTextColumn  5?   &   ,  &System.Windows.Controls.DataGridColumn   Header$ Student code��69      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6o   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6O   �� *StudentCode+6o     5@   &   $
 Mssv��69   $	 100 6`    6G   �� *Mssv+6`     5A   &   $ 	Full Name��69   $	 150 6i    6L   �� *
FullName+6i     5B   &   $ Class��69   $	 100 6d    6H   �� *	ClassId+6d     5C   &   $ Gender��69   $	 100 6d    6I   �� *Gender+6d   5E      5F      5G      �� 5J      $��Manage Classes��6   .��5K      � $��10q�6    5L      �� 5M   "   $
��115* �63   �� 5N   "   $
��177* �63   .+�5P      �� $��	Add Class��6%   $	��100��69   $��30��6E   $
��Left=�6Q   $	��Top=�6l   $��	10,10,0,0q�6�   �� 5Q      $��View Classes��6%   $	��100��6<   $��30��6H   $
��Left=�6T   $	��Top=�6o   $��
120,10,0,0q�6�     5S      -   5        $ 	dgClasses��5S   '   $ False��6:   $��10,50,10,10q�6V   $ False��6k   $��2��6�    5T   "     5U   &   $ 
Class Name��69   $	 150 6k    6M   �� *	ClassName+6k     5V   &   $ Course��69   $	 100 6d    6I   �� *Course+6d     5W   &   $ Description��69   $	 200 6n    6N   �� *Description+6n   5Y      5Z      5[      �� 5^      $��Manage Timetables��6   .��5_      � $��10q�6   .+�5`      �� $��Add Timetable��6%   $	��120��6=   $��30��6I   $
��Left=�6U   $	��Top=�6p   $��10q�6�   �� 5a      $��View Timetables��6%   $	��120��6?   $��30��6K   $
��Left=�6W   $	��Top=�6r   $��
140,10,0,0q�6�     5c      -   5        $ dgTimetables��5c   '   $ False��6=   $��10,50,10,10q�6Y   $ False��6n    5d   "     5e   &   $ 
Class Name��69   $	 150 6k    6M   �� *	ClassName+6k     5f   &   $
 Date��69   $	 100 6e    6G   �� *	ClassDate+6e     5g   &   $
 Time��69   $	 100 6e    6G   �� *	StartTime+6e     5h   &   $
 Room��69   $	 100 6`    6G   �� *Room+6`   5j      5k      5l      5m      �� 5p      $��1��6    �� Padding$ 10q�6)   $��2q�66   $��
10,-14,0,5q�6J   ��5q      �� 5r       �� ImageSource$O IC:\Users\Jackt\OneDrive\Hình ảnh\90d790d9f44c00cd2e86e537798f5d9f.jpg��6%    j� Stretch$ UniformToFill=�6{   5t      5u      5v      5w      5x      