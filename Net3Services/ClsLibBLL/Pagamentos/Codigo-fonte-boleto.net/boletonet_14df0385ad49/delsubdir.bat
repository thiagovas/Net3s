FOR /F "tokens=*" %%G IN ('DIR /B /AD /S %1*') DO RMDIR /S /Q "%%G"