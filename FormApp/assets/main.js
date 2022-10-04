const agregarFuncionalidadLimpiarInputs = () => {
  const inputsDelForm = Array.from(form.querySelectorAll('.form__input'));
  botonLimpiar = document.querySelector(".form__button-limpiar");
  botonLimpiar.addEventListener('click', e => {
    inputsDelForm.forEach(input => input.value = '');
  });
}

const validarFormulario = selectorDelForm => {
  const elementoForm = document.querySelector(selectorDelForm);

  const opcionesValidacion = [
    {
      atributo: 'required',
      esValido: input => input.value.trim() !== '',
      mensajeError: (input, label) => `El campo ${label.textContent} debe ser rellenado`
    },
  ];

  const validarUnGrupo = (grupoForm) => {
     const labelDelGrupo = grupoForm.querySelector('label');
     const inputDelGrupo = grupoForm.querySelector('input, textarea');
     const contenedorErrorDelGrupo = grupoForm.querySelector('.form__grupo-mensajeError');
    
     let hayUnError = false;
     for(const opcion of opcionesValidacion) {
      if(inputDelGrupo.hasAttribute(opcion.atributo) && !opcion.esValido(inputDelGrupo)) {
        contenedorErrorDelGrupo.textContent = opcion.mensajeError(inputDelGrupo, labelDelGrupo);
        hayUnError = true;
      }
     }
     
     if (!hayUnError) {
      contenedorErrorDelGrupo.textContent = '';
     }
  };

  elementoForm.setAttribute('novalidate', '');
  elementoForm.addEventListener('submit', e => {
    e.preventDefault();
    validarGruposDelForm(elementoForm);
  });

  // creo un array con los 3 grupos (divs) de mi form y los valido de a uno
  const validarGruposDelForm = form => {
    const gruposDelForm = Array.from(form.querySelectorAll('.form__grupo'));
    gruposDelForm.forEach(grupoForm => {
      validarUnGrupo(grupoForm);
    });
  };
}

validarFormulario("form");
agregarFuncionalidadLimpiarInputs();