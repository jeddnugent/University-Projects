#include "IntVector.h"
#include "CocktailShakerSort.h"


void CocktailShakerSort::operator()(IntVector& aContainer) const 
{
	int i, j;

	for (i = 0; i < aContainer.size() - 1; i++)
	{
		for (j = 0; j < aContainer.size() - i - 1; j++)
		{
			if (aContainer[j] > aContainer[j + 1])
			{
				aContainer.swap(j, j + 1);
			}
		}
	}
}

