#
#
# Python 2.7.13
#
# Author: Max Jacobsen
#
#
# Time 
# 
#
# 
#

from datetime import datetime, timedelta
import pytz


def less_than_24_hour(time_object):
    day_ago = current_utc() - timedelta(days=1)
    time_utc = pytz.utc.localize(time_object)
    return (day_ago < time_utc)


def utc_from_timestamp(timestamp):
    return datetime.utcfromtimestamp(timestamp)

def current_utc() :
    # getting current time in utc
    return datetime.now(pytz.utc)

	
