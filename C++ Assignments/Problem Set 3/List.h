
// COS30008, List, Problem Set 3, 2021

#pragma once

#include "DoublyLinkedList.h"
#include "DoublyLinkedListIterator.h"

#include <stdexcept>

using namespace std;

template<typename T>
class List
{
private:
    // auxiliary definition to simplify node usage
    using Node = DoublyLinkedList<T>;

    Node* fRoot;	// the first element in the list
    size_t fCount;	// number of elements in the list

public:
    // auxiliary definition to simplify iterator usage
    using Iterator = DoublyLinkedListIterator<T>;

    ~List()                                                             // destructor - frees all nodes
    {
        while (fRoot != nullptr)
        {
            if (fRoot != &fRoot->getPrevious())                       // more than one element
            {
                Node* lTemp = const_cast<Node*>(&fRoot->getPrevious()); // select last

                lTemp->isolate();                                       // remove from list
                delete lTemp;                                           // free
            }
            else
            {
                delete fRoot;                                           // free last
                break;                                                  // stop loop
            }
        }
    }

    void remove(const T& aElement)	                                // remove first match from list
    {
        Node* lNode = fRoot;                                            // start at first

        while (lNode != nullptr)                                      // Are there still nodes available?
        {
            if (**lNode == aElement)                                  // Have we found the node?
            {
                break;                                                  // stop the search
            }

            if (lNode != &fRoot->getPrevious())                       // not reached last
            {
                lNode = const_cast<Node*>(&lNode->getNext());           // go to next
            }
            else
            {
                lNode = nullptr;                                        // stop search
            }
        }

        // At this point we have either reached the end or found the node.
        if (lNode != nullptr)                                         // We have found the node.
        {
            if (fCount != 1)                                          // not the last element
            {
                if (lNode == fRoot)
                {
                    fRoot = const_cast<Node*>(&fRoot->getNext());       // make next root
                }
            }
            else
            {
                fRoot = nullptr;                                        // list becomes empty
            }

            lNode->isolate();                                           // isolate node
            delete lNode;                                               // release node's memory
            fCount--;                                                   // decrement count
        }
    }

    // PS3 starts here

    // P1

    List()
    {
        fRoot = nullptr;
        fCount = 0;
    }                                  							

    bool isEmpty() const
    {
        return fRoot == nullptr;
    }                    						
    size_t size() const
    {
        return fCount;
    };               							


    // adds aElement at front
    void push_front(const T& aElement)
    {
        Node* NewItem = new Node(aElement);

        if (fRoot != nullptr)
        {
            fRoot->push_front(*NewItem);
            fRoot = NewItem;
        }
        else
        {
            fRoot = NewItem;
        }
        fCount++;
    }    						

    Iterator begin() const                                              
    {
        return fRoot;
    }
    Iterator end() const                                                
    {
        return begin().end();
    }
    Iterator rbegin() const                                             
    {
        return begin().rbegin();
    }
    Iterator rend() const
    {
        return rend();
    }                  						

    // P2


    // adds aElement at back
    void push_back(const T& aElement)
    {
        Node* NewItem = new Node(aElement);

        //if the first element is empty the back is the front
        if (fRoot == nullptr)
        {
            fRoot = NewItem;
        }
        else //the back is the back
        {
            Node& LastItem = const_cast<Node&>(fRoot->getPrevious());
            LastItem.push_back(*NewItem);
        }
        fCount++;
    }    						

    // P3

    const T& operator[](size_t aIndex) const
    {
        //range check
        if (aIndex < fCount)
        {
            const Node* TempNode = fRoot;
            for (size_t i = 0; i < aIndex; i++)
            {
                TempNode = &TempNode->getNext();
            }
            return **TempNode;
        }
        else
        {
            throw range_error("Index entered out of range");
        }
    }

    // P4

    List(const List& aOtherList)
    {
        //intialise list
        fRoot = nullptr;
        fCount = 0;

        // copy over new list
        for (const auto& i : aOtherList)                             
        {
            push_back(i);                                          
        }

    }

    List& operator=(const List& aOtherList)
    {
        
        //Delete current node to allow it to be replaced
        while (fRoot != nullptr)
        {
            delete fRoot;
            fRoot = nullptr;
        }
                                        
        //repopulate
        fCount = 0;
        for (const auto& i : aOtherList)                              
        {
            push_back(i);                                             
        }

        return *this;                                                  
    }					

    // P5X

    // move features
    List(List&& aOtherList);                 							// move constructor
    List& operator=(List&& aOtherList);       						// move assignment operator
    void push_front(T&& aElement);            						// adds aElement at front
    void push_back(T&& aElement);             						// adds aElement at back
};
