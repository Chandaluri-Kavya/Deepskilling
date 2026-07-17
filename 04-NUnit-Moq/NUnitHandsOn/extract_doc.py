import zipfile, re, os, sys
path = r'c:\Users\Administrator\Downloads\1. NUnit-Handson.docx'
print('exists', os.path.exists(path))
if os.path.exists(path):
    with zipfile.ZipFile(path) as z:
        xml = z.read('word/document.xml').decode('utf-8', errors='ignore')
    text = re.sub(r'<[^>]+>', ' ', xml)
    text = re.sub(r'\s+', ' ', text)
    print(text[:20000])
else:
    print('file not found')
