#
#
# Python 3.6.1
#
# Author: Max Jacobsen
#
#
#
# Purpose: Create a GUI that allows the user to select a file to check for 
# newly created and modified files. Allow the user to select a folder to 
# move these files too. Create a button that initiates the process
#
#   
# Please change the file path for your desktop in order for this program to work correctly.
#

from tkinter import *
import tkinter as tk

import file_mod

def load_gui(self):
    
    self.lbl_title = tk.Label(self.master, wraplength=450,
        text="Select a source folder to check for modified or newly created files made within the last day and the destination you want to move those files too.")  
    self.lbl_title.grid(row=0, rowspan=2, padx=(20, 20), pady=(20,0), column=0, columnspan=10, sticky=N+W)

    self.lbl_srcfolder = tk.Label(self.master, text="Please Select a Folder", wraplength=350, justify="center")  
    self.lbl_srcfolder.grid(row=3,rowspan=2, padx=(5,0), pady=(20,0), column=2, columnspan=8, sticky=W)
    
    self.btn_srcfolder = tk.Button(self.master,bg="#CCCCCC", width=15, height=1, text="Source Folder",
                            command=lambda: file_mod.set_file_path(self, 'srcFolder', self.lbl_srcfolder))
    self.btn_srcfolder.grid(row=3, column=0, columnspan=2, padx=(20,0), pady=(20,0), sticky=W)

    self.lbl_destfolder = tk.Label(self.master, text="Please Select a Folder", wraplength=350, justify="center")  
    self.lbl_destfolder.grid(row=5, rowspan=2, padx=(5,0), pady=(20,0), column=2, columnspan=8, sticky=W)
    
    self.btn_destfolder = tk.Button(self.master,bg="#CCCCCC", width=15, height=1, text="Destination Folder",
                            command=lambda: file_mod.set_file_path(self, 'destFolder', self.lbl_destfolder))
    self.btn_destfolder.grid(row=5, column=0, columnspan=2, padx=(20,0), pady=(20,0), sticky=W)

    self.btn_filecheck = tk.Button(self.master,bg="#25c638", width=15, height=2, text="Check Files",
                            command=lambda: file_mod.file_check_initiated(self.srcFolder, self.destFolder, self.lbl_checktime, self.lbl_agotime,self.btn_refresh))
    self.btn_filecheck.grid(row=8, column=0, columnspan=2, padx=(20,0), pady=(40,0), sticky=W)

    self.lbl_checktime = tk.Label(self.master, fg="#2d8390", font=(None, 8, 'bold'),  text="No previous file check time found")  
    self.lbl_checktime.grid(row=8, padx=(15,0), pady=(20,0), column=2, columnspan=6, sticky=W)

    self.lbl_agotime = tk.Label(self.master, fg="black", font=(None, 8, 'bold'),  text="")  
    self.lbl_agotime.grid(row=8, padx=(15,0), pady=(60,0), column=2, columnspan=4, sticky=W)

    self.btn_refresh = tk.Button(self.master,bg="#CCCCCC", width=12, height=1, text="Refresh",
                            command=lambda: file_mod.check_for_last_file_check(self.lbl_checktime, self.lbl_agotime, self.btn_refresh))
    self.btn_refresh.grid(row=8, column=7, columnspan=3, padx=(0,0), pady=(40,0), sticky=W)

    
    
    file_mod.create_db(self)
    file_mod.check_for_last_file_check(self.lbl_checktime, self.lbl_agotime,self.btn_refresh)


if __name__ == "__main__":
    pass
    

