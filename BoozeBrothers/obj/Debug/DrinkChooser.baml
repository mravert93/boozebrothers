   M S B A M L   `   `   `  ����  BoozeBrothers     BoozeBrothers.DrinkChooser   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      S OMicrosoft.Kinect.Toolkit, Version=1.8.0.0, Culture=neutral, PublicKeyToken=null\ XMicrosoft.Kinect.Toolkit.Controls, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null2k(http://schemas.microsoft.com/kinect/2013   5      -   5          N� Title$  DrinkChooser��5	      .��5      � -   5         � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   8  2Microsoft.Kinect.Toolkit.Controls.KinectTileButton  -   5          Name$ drink0��5   *   $��0��6      Label$ Long Island Iced Tea��6:     5   
   -   5        $ drink1��5   *   $��0��6   $��Right=�6:   $ 	Margarita��6V     5   
   -   5        $ drink2��5   *   $��0��6   $
��Left=�6:   $ 	Hurricane��6U    � 5   
   -   5          �Name$ _popupFrame��5   T   $	��400��6   $	��400��6   
�������$y�Hidden=�6@   6T   :  4Microsoft.Kinect.Toolkit.Controls.KinectCircleButton  5   
   -   5          Name$ _stepsButton��5      $y�Hidden=�65   $��Right=�6I   $��0,160,304,124q�5       J� RenderTransformOrigin$ 
1.17,0.484&�6]   .��6�   Start6�     5!   
   -   5        $ drink3��5!   *   $��1��6   $ Adios��6:     5"   
   -	   5        $ drink4��5"   *   $��1��6   $ Pina Colada��6:   $
��Left=�6N     5#   
   $��1��6   $ Add A Drink��6*   $��Right=�6>   �� 5$   
   -
   5         ��Name$
 Test��5$      $y�Hidden=�6"   Testing voice thing out6P   5&      5'      