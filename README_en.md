# DICOM_RENAMER

"DICOM_RENAMER" is a C# program for renaming DICOM files.

# Features

This program makes it easier to organize and manage files by automatically generating filenames based on DICOM file metadata.

* **DICOM File Loading and Parsing**:
  * Filters the specified file list to process only DICOM files with the ".dcm" extension.
  * Extracts metadata such as PatientID, PatientName, RTPlanLabel (Radiotherapy Plan Label), Modality, and ReferencedBeamNumber from each DICOM file.

* **Filename Generation and Renaming**:
  * Generates new filenames based on DICOM file metadata.
  * If the modality is "RTPLAN," a new filename is created using the RTPlanLabel.
  * If the modality is "RTDOSE," it searches for the related RTPLAN file, retrieves the appropriate RTPlanLabel, and generates a filename.
  * Once the new filename is generated, the file is renamed accordingly.
  * This program is specifically tailored for the folder hierarchy of SunNuClear's software.

# Demo

None

# Requirement

None

# Installation

1. Copy the DICOM_RENAMER folder, which includes DICOM_RENAMER.exe, to any location on your PC.
2. Open Windows Explorer, type "shell:sendto" in the address bar, and the SendTo folder will open.
3. Create a shortcut for DICOM_RENAMER.exe within the DICOM_RENAMER folder and save it in the SendTo folder.

# Usage

**Note: Use this source code at your own risk.**

1. Select the file(s) you want to rename, right-click, and choose DICOM_RENAMER from the "Send to" menu.
2. Confirm that the selected file(s) have been renamed correctly.

# Author

* Takashi Kodama

# License
