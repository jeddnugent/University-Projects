#include "Polynomial.h"
#include <cmath>

using namespace std;

// new methods in problem set 1

    // call operator to calculate polynomial for a given x (i.e., aX)
double Polynomial::operator()(double aX) const
{
    double Result = 0.0;
    for (int i = fDegree; i >= 0; i--)
    {
        Result += pow(aX, i)* fCoeffs[i];
    }
    return Result;
}

// compute differential: the differential is a fresh polynomial with degree
// fDegree-1, the method does not change the current object
Polynomial Polynomial::getDifferential() const
{
    Polynomial Result;
    
    if (fDegree > 0)
    {
        Result.fDegree = fDegree - 1;
    }
    else
    {
        Result.fDegree = 0;
    }

    for (int i = Result.fDegree; i >= 0; i--)
    {
        Result.fCoeffs[i] = fCoeffs[i+1] * (i + 1);
    }
    
    
    return Result;
}

// compute indefinite integral: the indefinite integral is a fresh
// polynomial with degree fDegree+1
// the method does not change the current object
Polynomial Polynomial::getIndefiniteIntegral() const
{
    Polynomial Result;

    Result.fDegree = fDegree + 1;
    for (int i = 1; i <= Result.fDegree; i++)
    {
        Result.fCoeffs[i] = fCoeffs[i-1] / i;
    }


    return Result;
}

// calculate definite integral: the method does not change the current
// object; the method computes the indefinite integral and then
// calculates it for xlow and xhigh and returns the difference
double Polynomial::getDefiniteIntegral(double aXLow, double aXHigh) const
{
    Polynomial indefiniteIntegral = getIndefiniteIntegral();

    return (indefiniteIntegral(aXHigh) - indefiniteIntegral(aXLow));
}