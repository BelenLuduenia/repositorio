
SubProceso tarj_debito(tarjeta)
	
	// cuando el usuario ingresa la tarjeta, la maquina elige entre dos valores (0 o 1), dependiendo de como se coloco la tarjeta, en vase a esto se podra proseguir o no.
	// en este caso, lo realizare de forma manual como ejemplo
	escribir" Ingrese la tarjeta";
	escribir"tarjeta<-0"; // la tarjeta esta introducida de forma incorrecta//
	escribir"tarjeta<-1"; // la tarjeta esta introducida de forma correcta//
	leer tarjeta[1];
	
FinSubProceso

SubProceso codigo(cod_verf)
	// lista de codigos de verificación de la tarjeta.
	// la maquina, tomara un codigo que tiene cada tarjeta, que servira para verificar si esta habilitada para su uso, de lo contrario aparecera como "tarjeta sera bloqueada".
	// a modo de ejemplo, se realizara en forma manual.
	
	escribir "cod_verf<-111";
	escribir "cod_verf<-555";
	leer cod_verf[1] ;
	limpiar pantalla;
	
finsubproceso

subproceso claves(clave)
	// la maquina, le pedira al usuario que introduzca su clave
	// el codigo de seguridad debe coincidir con la clave, ejemplo para el codigo 111, la clave debe ser 256.
	// solo tendra tres intentos para colocar la clave correctamete, de lo contraio, la tarjeta sera retenida.
	
	escribir "clave<-256"; //cod_verf<-111
	escribir "clave<-024"; //cod_verf<-555
	leer clave[1];
	
FinSubProceso

Proceso cajero_automatico
	// definicion de variables
	definir cod_verf como entero;
	definir tarjeta como entero;
	definir clave como entero;
	definir opcion como entero;
	definir opcion1 como entero;
	definir contador como entero;
	definir opcion2 como entero;
	definir opcion3 como entero;
	definir opcion4 como entero;
	definir saldoactual como entero;
	definir saldo como entero;
	definir deposito como entero;

	
	dimension tarjeta[2];
	tarj_debito(tarjeta);
	dimension cod_verf[3];
	dimension clave[3];
	
	contador<-0;
	saldoactual<-100000;
	
	
	si tarjeta[1]=0 Entonces
		escribir" su tarjeta no pudo ser leida, por favor retire su tarjeta e introduzcala nuevamente";
		esperar tecla;
	sino
		
		si tarjeta[1]=1 Entonces
			codigo(cod_verf);
			si cod_verf[1]= 111 O cod_verf[1]=555  Entonces
				escribir "                             BIENVENIDO a        ";
				escribir "                              Banco xxx            ";
				escribir " ....................................................................";
				escribir" ";
				
				escribir" * ingrese su clave de acceso personal";
				claves(clave);
				
				si cod_verf[1]= 111 y clave[1]=256 O cod_verf[1]=555 y clave[1]=024 Entonces
					escribir" clave correcta";
					
				SiNo
					repetir
						escribir" clave no valida, ingrese la clave nuevamente";
						leer clave[1];
						contador<-contador+1;
					hasta que contador=2 O cod_verf[1]= 111 y clave[1]=256 O cod_verf[1]=555 y clave[1]=024 
					
				finsi	
				
				si  cod_verf[1]= 111 y clave[1]=256 O cod_verf[1]=555 y clave[1]=024  entonces 
					esperar 2 segundo;
					escribir"....................................................................";
					escribir" * seleccione el tipo de operacion que desea realizar";
					escribir"";
					escribir"1-extracciones";
					escribir"2-consultas";
					escribir"3-deposito";
					escribir"4-salir";
					leer opcion;
					
					Segun opcion Hacer
						
						1: // estracciones
							
							Repetir
								
								escribir"                        ATENSION             ";
								escribir" (SOLO PODRA EXTRAER MONTOS DESDE LOS 100 HASTA 5000 PESOS)";
								escribir" ingrese el monto que desee extraer";
								leer opcion1;
								
								si opcion1 >=100  y opcion1 <=5000 entonces
									
									saldo<-saldoactual-opcion1;
									escribir " tu saldo actual es:$", saldo;
								sino
									
									escribir "ERROR - por favor, intente nuevamente";
									escribir"  ";
									
								FinSi
								
							hasta que opcion1 >=100  y opcion1 <=5000
							
							escribir" por favor, retire su dinero";
							esperar 2 segundos;
							escribir"";
							escribir" ¿desea imprimir el ticket?";
							escribir "1-si";
							escribir "2-no";
							leer opcion2;
							
							Segun opcion2 Hacer
								1:
									escribir" saldo inicial :$", saldoactual;
									escribir" retiro:$", opcion1;
									escribir" saldo final:$", saldo;
									esperar tecla;
									
								2:
									esperar tecla;
									
							FinSegun
							
						2:
							// consulta de saldo
							escribir " tu saldo actual es:$", saldoactual;
							escribir"";
							escribir" ¿desea imprimir el ticket?";
							escribir "1-si";
							escribir "2-no";
							leer opcion3;
							
							Segun opcion3 Hacer
								1:
									escribir" Banco xxx";
									escribir" saldo actual:$", saldoactual;
									esperar tecla;
								2:
									esperar tecla;
									
							FinSegun
							
						3:
							// deposito
							
							repetir
								escribir"                        ATENSION             ";
								escribir" (SOLO PODRA DEPOSITAR MONTOS DESDE LOS 100 HASTA 5000 PESOS)";
								escribir" ingrese el monto que desee depositar";
								leer deposito;
								
								si deposito >=100  y deposito <=5000 entonces
									
									saldo<-saldoactual+deposito;
									escribir " tu nuevo saldo es:$", saldo;
								sino
									
									escribir "ERROR - por favor, intente nuevamente";
									escribir"  ";
									
								FinSi
								
							hasta que deposito >=100  y deposito <=5000
							
							escribir"";
							escribir" ¿desea imprimir el ticket?";
							escribir "1-si";
							escribir "2-no";
							leer opcion4;
							
							Segun opcion4 Hacer
								1:
									escribir" saldo inicial:$", saldoactual;
									escribir" deposito:$", deposito;
									escribir" saldo final:$", saldo;
									esperar tecla;
									
								2:
									esperar tecla;
									
							FinSegun
							
						4:
							// salir
							esperar tecla;
							
					FinSegun
					
				sino
					escribir" su tarjeta ha sido retenida";
					escribir" por favor, dirijase a nuestras sucursales para solucionar el probelma";
				FinSi
			sino	
				
				escribir "...tarjeta bloqueda, dirijase a la sucursal mas cercana para solucionar el problema...";
				esperar tecla;
				
			FinSi
			
		FinSi
	finsi
	
	
FinProceso
