#include "IntVector.h"
#include "CocktailShakerSort.h"
#include <iostream>       
#include <stdexcept>


using namespace std;

IntVector::IntVector(const int aArrayOfIntegers[], size_t aNumberOfElements)
{
	fNumberOfElements = aNumberOfElements;
	fElements = new int[fNumberOfElements];

	for (size_t i = 0; i < fNumberOfElements; i++)
	{
		fElements[i] = aArrayOfIntegers[i];
	}
}

IntVector::~IntVector()
{
	delete[] fElements;
}

size_t IntVector::size() const
{
	return fNumberOfElements;
}

void IntVector::swap(size_t aSourceIndex, size_t aTargetIndex)
{
	int s = 0;
	if(aSourceIndex <= fNumberOfElements && aTargetIndex <= fNumberOfElements)
	{
		s = fElements[aSourceIndex];
		fElements[aSourceIndex] = fElements[aTargetIndex];
		fElements[aTargetIndex] = s;
	}
	else
	{
		throw out_of_range("Illegal vector Indicies");

	}
}

void IntVector::sort(const IntSorter& aSorter)
{ 
	aSorter(*this);
}

const int IntVector::operator[](size_t aIndex) const
{
	if (aIndex < fNumberOfElements)
	{
		return fElements[aIndex];
	}
	
	throw out_of_range("Illegal vector index");
}

IntVectorIterator IntVector::begin() const
{
	return IntVectorIterator(*this);
}

IntVectorIterator IntVector::end() const
{
	return IntVectorIterator(*this, size());
}
