#include "BernsteinBasePolynomial.h"
#include <cmath>

using namespace std;

// constructor for b(0,0)
BernsteinBasePolynomial::BernsteinBasePolynomial() : fFactor(0, 0){}

// constructor for b(v,n)
BernsteinBasePolynomial::BernsteinBasePolynomial(unsigned int aV, unsigned int aN) : fFactor(aN, aV) {}


// call operator to calculate Berstein base
// polynomial for a given x (i.e., aX)
double BernsteinBasePolynomial::operator()(double aX) const
{
	return (fFactor() * pow(aX, fFactor.getK()) * pow(1 - aX, fFactor.getN() - fFactor.getK()));
}