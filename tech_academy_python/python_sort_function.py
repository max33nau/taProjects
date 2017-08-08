#
#
# Python 3.6.1
#
# Author: Max Jacobsen
#
#
#
# Purpose: Complete sorting drill
#
#
#


def sortList(unsortedList) :
    exchanges = True
    while exchanges:
        exchanges = False
        for num in range(len(unsortedList)-1, 0, -1):
            for i in range(num):
                if unsortedList[i] > unsortedList[i+1] :
                    exchanges = True
                    higherValue = unsortedList[i]
                    unsortedList[i] = unsortedList[i+1]
                    unsortedList[i+1] = higherValue
    return unsortedList



# First list

firstList = [67,45,2,13,1,998]

print('First list before sorted: ' + str(firstList))

firstList = sortList(firstList)

print('First list after sorted: ' + str(firstList))


# Second list

secondList = [89,23,33,45,10,12,45,45,45]

print('\nSecond list before sorted: ' + str(secondList))

firstList = sortList(secondList)

print('Second list after sorted: ' + str(secondList))
