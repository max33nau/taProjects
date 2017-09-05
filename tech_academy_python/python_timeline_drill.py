#
#
# Python 2.7.13
#
# Author: Max Jacobsen
#
#
#
# Purpose: To complete the Datetime -- Python 2.7 -- IDLE drill,
# this drill is meant for a company that just opened two new branches,
# one in NYC and the other in London. The goal is to so be able to run a
# program to see if either of the branches are opened or closed based on the
# the current time in Portland.
#
# Make sure you have pytz installed in order to run this program.
#

from datetime import datetime, timedelta
from pytz import timezone
import pytz

def is_branch_open(branch, b_open, b_close) :
    try :
        portland_branch_time = get_portland_branch_time()
        portland_branch_hour = portland_branch_time.hour
        if (branch == 'London') :
            other_branch_hour = portland_branch_hour + 8
        elif (branch == 'New York') :
            other_branch_hour = portland_branch_hour + 3
        else :
            print('This branch is not supported')
            raise Exception('Invalid Branch')

        if(other_branch_hour >= b_open and other_branch_hour <= b_close) :
            branch_status = 'open'
        else :
            branch_status = 'closed'

        print('The current branch located in {} is currently {}.'.format(branch, branch_status))
    except:
        print('An error occured while trying to access branch information.') 


def get_portland_branch_time() :
    # getting current time in utc
    now_utc = datetime.now(pytz.utc)
    return now_utc.astimezone(timezone('US/Pacific'))
    

def get_other_branches_status() :
    is_branch_open('London', 9, 21)
    is_branch_open('New York', 9,21)
    

if __name__ == '__main__':
    get_other_branches_status()
