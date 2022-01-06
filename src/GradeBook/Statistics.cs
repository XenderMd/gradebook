using System;

namespace GradeBook {

    public class Statistics{
        public double high;
        public double low;
        public double average;

        public Statistics(){
            high = double.MinValue;
            low = double.MaxValue;
            average = 0.0;
        }
    };
    
}