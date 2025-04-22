#include "Point2DSet.h"
#include <algorithm>
#include <fstream> 

using namespace std;
using Iterator = std::vector<Point2D>::const_iterator;


bool orderByCoordinates(const Point2D& aLeft, const Point2D& aRight)
{
	return aLeft < aRight;
}

bool orderByPolarAngle(const Point2D& aLHS, const Point2D& aRHS)
{
	if(aLHS.isCollinear(aRHS))
	{
		return aLHS.magnitude() - aRHS.magnitude() <= -0.0001;
	}
	return aLHS.direction() - aRHS.direction() <= -0.0001;
}

void Point2DSet::add(const Point2D& aPoint)
{
	fPoints.push_back(aPoint);
}

void Point2DSet::add(Point2D&& aPoint)
{
	fPoints.push_back(aPoint);
}

void Point2DSet::removeLast()
{
	fPoints.pop_back();
}

bool Point2DSet::doesNotTurnLeft(const Point2D& aPoint) const {
	return aPoint.isClockwise(fPoints[size() - 2], fPoints[size() - 1]);
}

void Point2DSet::populate(const std::string& aFileName)
{
    ifstream lInput(aFileName);
    int fSize = 0;
	Point2D readIn;

    if (lInput.good())
    {
        lInput >> fSize;

        if (fSize)
        {

            for (size_t i = 0; i < fSize; i++)
            {
				lInput >> readIn;
				add(readIn);
            }
        }

        lInput.close();
    }
}

void Point2DSet::buildConvexHull(Point2DSet& aConvexHull)
{
	// sort coordiantes
	sort(orderByCoordinates);

	//ORIGINS!!!
	for (Point2D& s: fPoints)
	{
		s.setOrigin(fPoints[0]);
	}
	// Santans House
	sort(orderByPolarAngle);


	//FIRST THREE NOT LAST
	for (size_t i = 0; i < 3; i++)
	{
		aConvexHull.add(move(fPoints[i]));
	}

	//Graeme Souness Sort
	for (int i = 3; i < size(); i++)
	{
		while (aConvexHull.doesNotTurnLeft(fPoints[i]))
			aConvexHull.removeLast();
		aConvexHull.add(move(fPoints[i]));
	}

}



size_t Point2DSet::size() const
{
	return fPoints.size();
}

void Point2DSet::clear()
{
	fPoints.clear();
}

void Point2DSet::sort(Comparator aComparator)
{
	stable_sort(fPoints.begin(), fPoints.end(), aComparator);
}

const Point2D& Point2DSet::operator[](size_t aIndex) const
{
	if (aIndex <= fPoints.size())
	{
		return fPoints[aIndex];
	}
	throw out_of_range("Illegal vector index");
}

Iterator Point2DSet::begin() const
{
	return fPoints.begin();
}

Iterator Point2DSet::end() const
{
	return fPoints.end();
} 
