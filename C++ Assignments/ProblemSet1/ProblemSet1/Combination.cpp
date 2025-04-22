#include "Combination.h"

using namespace std;


    // constructor for combination n over k
Combination::Combination(unsigned int aN, unsigned int aK) {fN = aN; fK = aK;}
   


unsigned int Combination::getN() const {return fN;}

unsigned int Combination::getK() const {return fK;}

unsigned long long Combination::operator()() const
    {
        unsigned long long Result = 1;       
        
        for (unsigned long long i = 1; i <= fK; i++)
        {
            Result *= (fN - i + 1);
            Result /= i;
        }             
        return Result;
    }


