namespace E01_MoblePhones
{
    using System;

    // 01. Define class:
    public class Display
    { 
        private double? size;
        private string numberOfColors;

        // 02. Constructors:
        internal Display()
            :this(null)
        {
        }
                
        public Display(double? size)
            : this(size, null)
        {
        }

        public Display(double? size, string numberOfColors)
        {            
            this.Size = size;
            this.NumberOfColors = numberOfColors;
        }

        
        // 05. Properties:  
        public double? Size
        {
            get
            {
                return this.size;
            }

            set
            {
                if (value != null && value < 0)
                {
                    throw new ArgumentOutOfRangeException("The size should be a positive " + 
                        "number, and not zero ! ");
                }

                this.size = value;
            }
        }

        public string NumberOfColors
        {
            get
            {
                return this.numberOfColors;
            }

            set
            {                                              
                this.numberOfColors = value;
            }
        }

        // 04. ToString:
        public override string ToString()
        {
            return string.Format("\r\n\tSize: {0}\r\n\tNumber of colors: {1}",
                this.Size, this.NumberOfColors);
        }
    }
}
