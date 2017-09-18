#
#
# Python 3.6.1
#
# Author: Max Jacobsen
#
#
#
# Purpose: To complete the File Mover -- Python 3.6 -- IDLE drill,
# Complete user interface for file modification
#
# 
#


from tkinter import *
import tkinter as tk


import file_gui
import file_mod

# Top level Frame for GUI to mount on
class ParentWindow(Frame):
    # master is what we call the frame
    # anytime you see self that is a reference to our parent frame
    def __init__(self, master, *args, **kwargs):
        Frame.__init__(self, master, *args, **kwargs)

        self.master = master
        self.srcFolder = ''
        self.destFolder = ''
        self.master.minsize(500,300) # first argument is height, second is width
        self.master.maxsize(500,300)
        file_mod.center_window(self, 500, 300) # self is like a key and needed to affect all the widgets
        self.master.title("File Modification/Creation Checker")
        self.master.configure(bg="#F0F0F0")
        #windows specific event to catch when the user tries to leave, make it a good habbit to always pass in self
        self.master.protocol("WM_DELETE_WINDOW", lambda: file_mod.ask_quit(self)) 
        file_gui.load_gui(self)


if __name__ == '__main__' :
    root = tk.Tk()
    App = ParentWindow(root)
    root.mainloop()
