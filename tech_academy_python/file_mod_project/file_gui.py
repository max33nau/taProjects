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
                            command=lambda: file_mod.copy_modified_files(self.srcFolder, self.destFolder))
    self.btn_filecheck.grid(row=8, column=0, columnspan=10, padx=(20,0), pady=(40,0), sticky=W)
    



if __name__ == "__main__":
    pass
    

