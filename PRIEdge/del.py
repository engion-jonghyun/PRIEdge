import shutil
import os
import sys
# shutil.rmtree(r"toecim\bin")

rmlist = []
print ("지울 폴더들을 찾고 있습니다")
for dirpath, dirnames, filenames in os.walk('.'):
    for path in dirnames:
        if path.endswith("obj") or path.endswith("bin"):
            filename = os.path.join(dirpath, path)
            print(filename)
            rmlist.append(filename)

if (len(rmlist) == 0):
    print("지울 폴더가 없습니다")
    sys.exit()

s = input("위의 폴더들을 삭제하시겠습니까(y/n)?")
if (s == 'y'):
    for l in rmlist:
        shutil.rmtree(l)
        print(f'{l} removed')
else:
    print("취소되었습니다")