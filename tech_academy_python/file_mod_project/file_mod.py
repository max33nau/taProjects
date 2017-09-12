import os
import shutil
from datetime import datetime, timedelta
import pytz

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

def copy_modified_files(src, dest) :
    if os.path.exists(src) and os.path.exists(dest):
        mod_found = False
        for file_obj in os.listdir(src):
            file_path = os.path.join(src, file_obj)
            if(os.path.isfile(file_path) and os.path.splitext(file_path)[1] == '.txt'):
                if(modified_in_last_24_hours(file_path)):
                    shutil.copy(os.path.join(src, file_obj), os.path.join(dest, file_obj))
                    mod_found = True
                    print('Copied file {} from {} to {}.'.format(file_obj,src, dest))
        if(not mod_found):
            print('\n No files created or modified within the last 24 hours.')


def modified_in_last_24_hours(file_path):
    day_ago = datetime.now(pytz.utc) - timedelta(days=1)
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
