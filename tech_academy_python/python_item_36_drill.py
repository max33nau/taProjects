# Python 2.7.13
#
# Author : Max Jacobsen
#
# Purpose: Complete Python Course Item 36 by perfoming basic tasks that we
# have learned so far.
#
#



# 1. Assign an integer to a variable

total = 10

# 2. Assign a string to a variable

apple = 'Apple'

# 3. Assign a float to a variable

eaten = 7.77

# 4. Use the print function and .format() notation to print out the variable
#     you assigned

print('Today, I bought {0} {1}s from the supermarket and \nhave already ate {2} of them.'.format(total, apple, eaten))

# 5. Use each of these operators +, -, *, /, +=, =, %

left = total - eaten

people = 10

donated = people * 2

extraPerson = 1

donated += extraPerson * 2

total = left + donated

hungryPeople = 5

total = total / hungryPeople

print(total)

wholeTotal = total - (total % 4)

print('\nNot sure how we got here will all those generous and hungry people and weird math but you only have ' +
      str(wholeTotal) + ' full Apples left.' )

# 6. Use logical operators: and, or , not
# 7. use of conditional statements

if (wholeTotal < 5) and (eaten > 5):
    print('\nWoah you ate a lot of apples')
elif (wholeTotal > 0) or (total > 0):
    print('\nLooks like you still have some apples left')
else:
    print('No more apples for you')

fruits = ['Banana', 'Kiwi', 'Strawberry']

if apple not in fruits:
    print('\nhow can you forget about the apple')

# 8. use of a while loop
correct = False
my_number = 12
incorrect_guesses = []

while not correct :
    user_guess = raw_input('Please guess a number?  ')
    try: 
        if(user_guess == str(my_number)) :
            correct = True
            print('Congrats you guessed it right')
        elif(int(user_guess) < my_number) :
            print('Guess is too low')
        elif(int(user_guess) > my_number) :
            print('Guess is too high')
        else :
            print('not correct value entered, please enter a whole number')
    except:
        print('not cool, that is not a valid guess')
    if not correct :
        incorrect_guesses.append(user_guess)

#9. use of a for loop
# 10. Creates a list above and iterate through that list use a for loop to print each item

if(len(incorrect_guesses) > 0):
    print('Here is a list of your wrong guesses: ')
    for guess in incorrect_guesses :
        print('\n' + guess)
else :
    print('woah you got it on the first try, impressive')

# 11. Create a tuple and iterate through it using a for loop to print each item
print('\n lets count to 10')
tup = (1,2,3,4,5,6,7,8,9,10)
for num in tup :
    print(num)

# 12. Define a function that returns a string variable

def get_user_message():
    valid = False
    while not valid :
        message = raw_input('What would you like to say to everyone? ') 
        if(len(message) != 0) :
            valid = True
        else :
            print('must enter something')
    return message



# 13. Call the function you defined above and print the result
print(get_user_message())



