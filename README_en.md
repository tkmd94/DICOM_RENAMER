# DICOM_RENAMER

"DICOM_RENAMER" is a C# program for renaming DICOM files.

# Features

Utilizes DICOM file metadata to automatically generate filenames, making file organization and management easier.
* **Loading and Parsing DICOM Files**:
  * Filters and processes only DICOM files (with the .dcm extension) from the specified file list.
  * Retrieves metadata such as PatientID, PatientName, RTPlanLabel (radiation therapy plan label), Modality, and ReferencedBeamNumber from each DICOM file.
  
* **Filename Generation and Renaming**:
  * Generates new filenames based on the metadata of DICOM files.
  * For Modality "RTPLAN", creates a new filename using RTPlanLabel.
  * For Modality "RTDOSE", explores related RTPLAN files to obtain the appropriate RTPlanLabel and generates the filename.
  * Renames files with the newly generated filenames.
  * Specialized for the folder hierarchy structure of SunNuClear software.

# Demo

None

# Requirement

None

# Installation

1. Copy the folder containing DICOM_RENAMER.exe to any location on your PC.
2. Open Windows Explorer, type "shell:sendto" in the address bar, and the SendTo folder will open.
3. Create a shortcut for DICOM_RENAMER.exe within the DICOM_RENAMER folder and save it in the SendTo folder.

# Usage

**Note: Use this source code at your own risk.**

### Drag and Drop Files to Rename
1. Launch the program.
2. Select the files you want to rename and drag and drop them into the program window.
3. Verify that the selected files have been renamed correctly.

### Rename from Context Menu "Send To"
1. Select the files you want to rename, right-click, and choose DICOM_RENAMER from the SendTo menu.
2. Verify that the selected files have been renamed correctly.

# Author

* Takashi Kodama

# License

"DICOM_RENAMER" is licensed under the [MIT License](https://en.wikipedia.org/wiki/MIT_License) .
