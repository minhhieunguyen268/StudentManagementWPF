   M S B A M L   `   `   `  ����L  HStudentManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:StudentManagementStudentManagement  5   	   ,    &StudentManagement.StudentManagerWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:StudentManagement     5   	     � Title$  Student Manager��5   
   $	��694��6"   $	��925��6/    � WindowStartupLocation$ CenterScreen=�5	   	   .��5      ]� ���#F0F2F5.+�5   
   ]� $	��Top=�6   ���	#FF0C99DD$��50��6@   .+�5      �� -   5         ��Name$ 
txtWelcome��5      $��Hi, Teacher��6(   $��16(�6>   
�������$��Center=�5      $
��10,0q�6/   �� 5      -   5        $��Logout��5      $��80��6&   $��0,0,10,0q�61   $��Right=�5      $��Center=�61   6L   5      � 5   
   $��10q�6   ��5      �� 5       �� 
StartPoint$	 0,0&�6&    �� EndPoint$	 1,1&�67   .��5      �  � Color$ 	#FF2FBBFF��6#    � Offset$	 0.0Q�65   � 5      $ 	#FF0E2337��6#   $	 1.0Q�65   5       � RowDefinitions 5      �� 5      $
��Auto �6    �� 5       $��* �6    .+�5$      ��  �� Orientation$ 
Horizontal=�6   $��5q�62   $��0��6=   .+�5%      �� $��Name:��6   $��Center=�6(   �� 5&      -   5        	 ��Name$	 txtSearchName��5&      $	��180��61   $��5q�6=   �� 5'      $��Student ID:��6   $��Center=�6.   $��10,0,0,0q�6I   �� 5(      -   5        $	 txtSearchID��5(      $	��180��6/   $��5q�6;   �� 5)      -   5        
 ��Name$
 	btnSearch��5)      $��Search��6,   $��80��6=   $��10,0,0,0q�6H   6Z   5*      � 5-      $��1��6   $��5,10,5,5q�6     � ColumnDefinitions 5.      �� 5/      $��* �6'   �� 50      $	��300 �6'   .+�54      �� $��0��6   $��5q�6-   .@�56      �� $��Manage Students��6   .��57      � $��10q�6   .+�58      �� -   5        $
 btnAddStudent��58   %   $��Add Student��6<   $	��100��6R   $��30��6^   $
��Left=�6j   $	��Top=�6�   $��	56,10,0,0q�6�   ���#28A7456�   �� 59      -   5        $
 btnViewDetail��59   %   $��View Student Detail��6<   $	��110��6Z   $��30��6f   $��Center=�6r   $	��Top=�6�   $��0,10,0,0q�6�   ���#FFC1076�   �� 5:      -   5        $
 	btnDelete��5:   %   $��Delete Student��68   $	��110��6Q   $��30��6]   $
��Left=�6i   $	��Top=�6�   $��
423,10,0,0q�6�   ���#DC35456�   &   System.Windows.Controls.DataGrid  5<      -	   5          Name$ 
dgStudents��5<   '      AutoGenerateColumns$ False��6;   $��10,50,10,10q�6W      CanUserAddRows$ False��5=   V      Columns 5>   "   0  *System.Windows.Controls.DataGridTextColumn  5?   &   ,  &System.Windows.Controls.DataGridColumn   Header$ Student code��69      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6o   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6O   �� *StudentCode+6o     5@   &   $
 Mssv��69   $	 100 6`    6G   �� *Mssv+6`     5A   &   $ 	Full Name��69   $	 150 6i    6L   �� *
FullName+6i     5B   &   $ Class��69   $	 100 6d    6H   �� *	ClassId+6d     5C   &   $ Gender��69   $ * 6d    6I   �� *Gender+6d   5E      5F      5G      �� 5J      $��Manage Classes��6   .��5K      � $��10q�6    5L      �� 5M   "   $
��279* �63   �� 5N   "   $
��280* �63   .+�5Q      �� -
   5        $
 btnAddClass��5Q   %   $��	Add Class��6:   $	��100��6N   $��30��6Z   $
��Left=�6f   $	��Top=�6�   $��	69,10,0,0q�6�   ���#28A7456�   �� 5R      -   5        $
 btnViewClassDetail��5R   %   $��View Class Detail��6A   $	��110��6]   $��30��6i   $
��Left=�6u   $	��Top=�6�   $��
224,10,0,0q�6�   ���#FFC107$��2��6�   �� 5S      -   5        $
 btnDeleteClass��5S   %   $��Delete Class��6=   $	��110��6T   $��30��6`   $
��Left=�6l   $	��Top=�6�   $��
108,10,0,0q�6�   ���#DC3545$��1��6�     5U      -   5        $ 	dgClasses��5U   '   $ False��6:   $��10,50,10,10q�6V   $ False��6k   $��2��6�    5V   "     5W   &   $ 
Class Name��69   $	 150 6k    6M   �� *	ClassName+6k     5X   &   $ Course��69   $	 100 6d    6I   �� *Course+6d     5Y   &   $ Description��69   $	 200 6n    6N   �� *Description+6n   5[      5\      5]      �� 5`      $��Manage Timetables��6   .��5a      � $��10q�6   .+�5b      �� $��Add Timetable��6%   $	��120��6=   $��30��6I   $
��Left=�6U   $	��Top=�6p   $��10q�6�   �� 5c      $��View Timetables��6%   $	��120��6?   $��30��6K   $
��Left=�6W   $	��Top=�6r   $��
140,10,0,0q�6�     5e      -   5        $ dgTimetables��5e   '   $ False��6=   $��10,50,10,10q�6Y   $ False��6n    5f   "     5g   &   $ 
Class Name��69   $	 150 6k    6M   �� *	ClassName+6k     5h   &   $
 Date��69   $	 100 6e    6G   �� *	ClassDate+6e     5i   &   $
 Time��69   $	 100 6e    6G   �� *	StartTime+6e     5j   &   $
 Room��69   $	 100 6`    6G   �� *Room+6`   5l      5m      5n      5o      �� 5r      $��1��6    �� Padding$ 10q�6)   $��2q�66   $��
10,-14,0,5q�6J   ��5s      �� 5t       �� ImageSource$ /Images/siuu.jpg��6%    j� Stretch$ UniformToFill=�6D   5v      5w      5x      5y      5z      