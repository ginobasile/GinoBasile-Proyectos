function enviarDatos() {
	if (confirm("Enviar pedido???")) {

		let resultNombre = validarNombre(document.getElementById('Nombre').value);
		let resultApellido = validarApellido(document.getElementById('Apellido').value);
		let resultDireccion = validarDireccion(document.getElementById('Direccion').value);
		let resultTelefono = validarNroTel(document.getElementById('Telefono').value);
		
		console.log(resultDireccion);
		if (resultNombre == true && resultApellido == true && resultDireccion == true && resultTelefono == true) {
			alert("Datos correctos! Form enviado");
			return true;
		}
		else {
			//alert("Revise los datos que est\u00E1n mal cargados!");
			return false;
		}
	}
	else {
		return false;
	}
}

function validarNombre(Nombre) {
	

	if (Nombre != '') {
		return true;
	}
	else {
		alert("El campo nombre es de carga obligatoria!");
		document.getElementById('Nombre').focus();
		return false;
	}
}

function validarApellido(Apellido) {

	if (Apellido != '') {
		return true;
	}
	else {
		alert("El campo Apellido es de carga obligatoria!");
		document.getElementById('Apellido').focus();
		return false;
	}
}
function validarDireccion(Direccion) {
	if (Direccion != '') {
		return true;
	}
	else {
		alert("El campo dirección es de carga obligatoria!");
		document.getElementById('Direccion').focus();
		return false;
	}
}
function validarNroTel(inputtxt) {
	//recibe en el par�metro la referencia a un control input donde cargan el tel�fono

	var nrotel = /^\d{10}$/;

	if (inputtxt.match(nrotel)) {
		return true;
	}
	else {
		alert("El numero de tel\u00e9fono debe ser de 10 numeros");
		document.getElementById('Telefono').value = '';
		document.getElementById("Telefono").focus();

		return false;
	}
}
