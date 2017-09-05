##
## Python 3.6.1
##
##
## Author: Max Jacobsen
##
##
## Purpose: Complete databases and python course using sqlite3


import sqlite3


def create_db():
    # database is created if it is not already there
    connection = sqlite3.connect('teams_database.db')

    # to communicate across the connection we use the cursor method

    c = connection.cursor()

    c.execute("DROP TABLE IF EXISTS tbl_roster")

    c.execute("CREATE TABLE tbl_roster(Name TEXT, Species TEXT, IQ INT)")

    rosterValues = (
       ('Jean-Baptiste Zorg', 'Human', 122),
       ('Korben Dallas', 'Meat Popsicle', 100),
       ('''Ak'not''', 'Mangalore', -5)
    )

    c.executemany("INSERT INTO tbl_roster VALUES(?,?,?)", rosterValues)

    connection.commit()

    c.execute("UPDATE tbl_roster SET Species=? WHERE Name=?", ('Human', 'Korben Dallas'))

    connection.commit()

    c.execute("SELECT Name, IQ FROM tbl_roster WHERE Species='Human'")

    print('All the humans on the roster: ')
    while True:
        row = c.fetchone()

        if row is None:
            break

        print(row)

    connection.close()


if __name__ == '__main__':
    create_db()

    
