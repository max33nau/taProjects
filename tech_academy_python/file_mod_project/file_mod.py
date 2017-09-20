#
#
# Python 3.6.1
#
# Author: Max Jacobsen
#
#

import sqlite3

import os
import shutil
from datetime import datetime, timedelta
import pytz

import math

from tkinter import *
import tkinter as tk
from tkinter import messagebox
from tkinter.filedialog import askdirectory

#========= GUI FUNCTIONS

def center_window(self, width,height):
    screen_width = self.master.winfo_screenwidth()
    screen_height = self.master.winfo_screenheight()
    x = int((screen_width/2) - (width/2))
    y = int((screen_height/2) - (height/2))
    centerGeo = self.master.geometry('{}x{}+{}+{}'.format(width,height,x,y))
    return centerGeo

def ask_quit(self):
    if messagebox.askokcancel("Exit Program", "Okay to exit application?"):
        self.master.destroy()
        os._exit(0)


def set_file_path(self, folderName, selfLabel):
    filename = askdirectory()
    if filename:
        setattr(self,folderName,filename)
        selfLabel.config(text=filename)


def file_check_initiated(src,dest, timeLabel, agoLabel,btnRefresh):
    if os.path.exists(src) and os.path.exists(dest):
        current_time = datetime.now(pytz.utc)
        current_format_time = format_time(current_time)
        insert_file_check(current_format_time)
        copy_modified_files(src, dest, current_time)
        timeLabel.config(text="Last Checked: {}".format(current_format_time))
        agoLabel.config(text="Click refresh to get how long ago")
        btnRefresh.grid()
    else:
        messagebox.showerror("Error", "Source or destination folder not selected.")
        

def check_for_last_file_check(timeLabel, agoLabel, btnRefresh):
    lastCheck = get_last_file_check()
    if lastCheck is not None:
        last_check_time = datetime.strptime(lastCheck, '%Y-%m-%d %H:%M:%S')
        formatted_time = format_time(last_check_time)
        timeLabel.config(text="Last Checked: {}".format(formatted_time))
        get_how_long_ago(last_check_time, agoLabel)
    else:
        print('No last file check found')
        btnRefresh.grid_remove()

def get_how_long_ago(last_check_time, agoLabel):
    current_time = datetime.now(pytz.utc)
    current_format_time = format_time(current_time)
    current_timestamp = datetime.strptime(current_format_time, '%Y-%m-%d %H:%M:%S').timestamp()
    diff = current_timestamp - last_check_time.timestamp()
    if diff >= 86400:
        days = get_int_floor(diff/86400)
        dayString = "{} {} ".format(days, ("days" if days > 1 else "day"))
        diff = diff - (days * 86400)
    else:
        dayString = ""
    if diff >= 3600:
        hours = get_int_floor(diff/3600)
        hourString = "{} {} ".format(hours, ("hours" if hours > 1 else "hour"))
        diff = diff - (hours * 3600)
    else:
        hourString = ""
    if diff >= 60:
        minutes = get_int_floor(diff/60)
        minuteString = "{} {} ".format(minutes, ("minutes" if minutes > 1 else "minute"))
        diff = diff - (minutes * 60)
    else:
        minuteString = ""
    if diff < 60:
        seconds = get_int_ceil(diff)
        secondString = "{} {} ".format(seconds, ("seconds" if seconds > 1 else "second"))
    else:
        secondString = ""
    agoLabel.config(text="{}{}{}{}ago".format(dayString,hourString,minuteString,secondString))
        

def get_int_ceil(number):
    return int(math.ceil(number))

def get_int_floor(number):
    return int(math.floor(number))

#======== DIRECTORY FUNCTIONS

def copy_modified_files(src, dest, current_time) :    
    mod_found = False
    for file_obj in os.listdir(src):
        file_path = os.path.join(src, file_obj)
        if(os.path.isfile(file_path) and os.path.splitext(file_path)[1] == '.txt'):
            if(modified_in_last_24_hours(file_path, current_time)):
                shutil.copy(os.path.join(src, file_obj), os.path.join(dest, file_obj))
                mod_found = True
                print('Copied file {} from {} to {}.'.format(file_obj,src, dest))
    if(not mod_found):
        print('\n No files created or modified within the last 24 hours.')


def create_directory(path) :
    try: 
        if not os.path.exists(path):
            os.makedirs(path)
    except OSError:
        print('A error occured while trying to create a directory with file path {}'.format(path))

def create_directories(directories) :
    for path in directories:
        create_directory(path)

def empty_directory_files(directory_path) :
    if os.path.exists(directory_path):
        for file_object in os.listdir(directory_path):
            file_path = os.path.join(directory_path, file_object)
            if(os.path.isfile(file_path)):
               os.unlink(file_path)
    else :
        print('The file path {} does not exist so there is nothing to empty.'.format(directory_path))


def modified_in_last_24_hours(file_path, current_time):
    day_ago = current_time - timedelta(days=1)
    path_mod_utc = get_file_mod_time(file_path)
    within_24_hours = (day_ago < path_mod_utc)
    print('\nChecking file {}: '.format(file_path))
    print('Last modified or created = {}, \nWithin 24 hours? {}'.format(path_mod_utc, within_24_hours)) 
    return within_24_hours

def get_file_mod_time(path):
    path_stat = os.stat(path)
    # Different os systems handle file creation and modification differently
    # so this is a more cross platform safe solution to get the time
    path_stat = os.stat(path)
    try: 
        created = path_stat.st_ctime
    except:
        created = False
    try:
        modified = path_stat.st_mtime
    except:
        modified = False
    if(created > modified):
        timestamp = created
    else:
        timestamp = modified
    path_time = datetime.utcfromtimestamp(timestamp)
    return pytz.utc.localize(path_time)

def format_time(timeVal):
    return timeVal.strftime('%Y-%m-%d %H:%M:%S')


#================ SQL Functions

def create_db(self):
    conn = sqlite3.connect('file_mod.db')
    with conn:
        cursor = conn.cursor()
        cursor.execute("CREATE TABLE if not exists tbl_file_check_time( \
            ID INTEGER PRIMARY KEY AUTOINCREMENT, \
            col_check_time TEXT);")
        conn.commit()
    conn.close()
            

def get_last_file_check():
    conn = sqlite3.connect('file_mod.db')
    with conn:
        cursor = conn.cursor()
        cursor.execute("SELECT MAX(col_check_time) FROM tbl_file_check_time");
        recentTime = cursor.fetchone()
        conn.commit()
    conn.close()
    return recentTime[0]

def insert_file_check(fileCheckTime):
    conn = sqlite3.connect('file_mod.db')
    with conn:
        cursor = conn.cursor()
        cursor.execute("INSERT INTO tbl_file_check_time(col_check_time) VALUES (?)", (fileCheckTime,));
        conn.commit()
    conn.close()
            
    
