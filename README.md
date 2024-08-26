# DICOM_RENAMER

「DICOM_RENAMER」は、DICOMファイルのリネーム処理を行うC#プログラムです。


# Features

DICOMファイルのメタデータを利用してファイル名を自動生成するため、ファイルの整理や管理が容易になります。
* DICOMファイルの読み込みと解析:
  * 指定されたファイルリストの中からDICOMファイル（拡張子が.dcm）のみをフィルタリングし、それらを処理します。
  * 各DICOMファイルから、PatientID、PatientName、RTPlanLabel（放射線治療計画のラベル）、Modality（モダリティ）、およびReferencedBeamNumber（参照ビーム番号）などのメタデータを取得します。
  
* ファイル名の生成とリネーム:
  * DICOMファイルのメタデータに基づいて、新しいファイル名を生成します。
  * Modalityが"RTPLAN"の場合は、RTPlanLabelを使って新しいファイル名を作成します。
  * Modalityが"RTDOSE"の場合は、関連するRTPLANファイルを探索し、適切なRTPlanLabelを取得して、ファイル名を生成します。検索するフォルダ構造はSunNuClear社ソフトウェアに特化しています。
  * 新しいファイル名が生成されると、その名前でファイルをリネームします。

# Demo

なし

# Requirement

なし

# Installation

1. DICOM_RENAMER.exeを含むPDF_RENAMERフォルダをPCの任意の場所にコピーする。
3. エクスプローラーを起動し、アドレスバーに「shell:sendto」と入力すると、SendToフォルダが開かれる。
4. DICOM_RENAMERフォルダ内のDICOM_RENAMER.exeのショートカットを作成し、SendToフォルダに保存する。
   
# Usage

**※本ソースコードは自己責任で使用してください。**

### ファイルをドラッグアンドドロップしてリネーム
1. プログラムを起動する。
2. リネームしたいファイルを選択し、プログラムウィンドウにドラッグアンドドロップする。
3. 選択したファイルが正しくリネームされたことを確認する。

### コンテキストメニューの「送る」からリネーム
1. リネームしたいファイルを選択し、右クリックから送るメニュー内のDICOM_RENAMERを選択する。
2. 選択したファイルが正しくリネームされたことを確認する。



# Author
 
* Takashi Kodama
 
# License

"DICOM_RENAMER" は [MIT ライセンス](https://en.wikipedia.org/wiki/MIT_License)  の下にあります。
