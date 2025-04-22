#pragma once

#include "Point2D.h"
#include "Vector2D.h"
#include <cmath>

#include <iostream>
#include <string>

using namespace std;


static const Point2D gCoordinateOrigin;
Point2D::Point2D()
{
    fId = "";
    fPosition = (0, 0);
    fOrigin = &gCoordinateOrigin;
}

Point2D::Point2D(const std::string& aId, double aX, double aY) : fId(aId), fPosition(aX, aY), fOrigin(&gCoordinateOrigin)
{
}

Point2D::Point2D(std::istream& aIStream)
{
    double x, y;

    aIStream >> fId >> x >> y;

    fPosition.setX(x);
    fPosition.setY(y);
}



double Point2D::directionTo(const Point2D& aOther) const {
    return (*this - aOther).direction();
}

double Point2D::magnitudeTo(const Point2D& aOther) const {
    return (*this - aOther).magnitude();
}


const std::string& Point2D::getId() const
{
    return fId;
}

void Point2D::setX(const double& aX)
{
    fPosition.setX(aX);
}

const double Point2D::getX() const
{
    return fPosition.getX();
}

void Point2D::setY(const double& aY)
{
    fPosition.setY(aY);
}

const double Point2D::getY() const
{
    return fPosition.getY();
}

void Point2D::setOrigin(const Point2D& aPoint)
{
    fOrigin = &aPoint;
}

const Point2D& Point2D::getOrigin() const
{
    return *fOrigin;
}

Vector2D Point2D::operator-(const Point2D& aRHS) const
{
    return Vector2D(fPosition.getX() - aRHS.getX(), fPosition.getY() - aRHS.getY());
}

double Point2D::direction() const
{
    return directionTo(*fOrigin);
}

double Point2D::magnitude() const
{
    return magnitudeTo(*fOrigin);
}

bool Point2D::isCollinear(const Point2D& aOther) const
{
    if (fPosition.cross(aOther.fPosition) == 0)
    {
        return true;
    }
    else if (getX()/aOther.getX() == getY() / aOther.getY())
    {
        //Condition 2 is not valid if one of the components of the vector is zero.
        if (getX(), getY(), aOther.getY(), aOther.getX() != 0) {return true;}
        else {return false;}
    }
    else
    {
        return false;

    }
}

bool Point2D::isClockwise(const Point2D& aP0, const Point2D& aP2) const
{
    return (*this - aP0).cross((aP2 - aP0)) > 0;

}


bool Point2D::operator<(const Point2D& aRHS) const {
    Vector2D result = *this - aRHS;
    if (result.getY() <= -0.0001 || result.getY() == 0 && result.getX() <= -0.0001)
        return true;
    return false;
}


std::ostream& operator<<(std::ostream& aOStream, const Point2D& aObject)
{
    aOStream << aObject.fId << ": (" << aObject.fPosition.getX() << ", " << aObject.fPosition.getY() << ")";
    return aOStream;
}

std::istream& operator>>(std::istream& aIStream, Point2D& aObject)
{
    aObject = Point2D(aIStream);
    return aIStream;
}
