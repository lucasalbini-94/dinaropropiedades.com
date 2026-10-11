document.addEventListener('DOMContentLoaded', () => {
    // 1. Control de Pestañas
    const tabButtons = document.querySelectorAll('.tab-item');
    const tabPanes = document.querySelectorAll('.tab-pane');

    tabButtons.forEach(button => {
        button.addEventListener('click', () => {
            const targetId = button.getAttribute('data-tab');
            tabButtons.forEach(btn => btn.classList.remove('active'));
            tabPanes.forEach(pane => pane.classList.remove('active'));

            button.classList.add('active');
            const targetPane = document.getElementById(targetId);
            if (targetPane) targetPane.classList.add('active');
        });
    });

    // 2. Manejo y Compresión de Imágenes en Cliente
    const inputImagenes = document.getElementById('inputImagenes');
    const previewsGrid = document.getElementById('previewsGrid');
    const hfImagenesData = document.getElementById('hfImagenesData');

    // Lista en memoria de imágenes procesadas: { id, nombre, base64, orden }
    let coleccionImagenes = [];

    if (inputImagenes && previewsGrid) {
        inputImagenes.addEventListener('change', async (e) => {
            const files = Array.from(e.target.files);

            for (const file of files) {
                if (!file.type.startsWith('image/')) continue;

                // Evitar duplicar archivos por nombre y tamaño
                if (coleccionImagenes.some(img => img.nombre === file.name && img.tamanoOriginal === file.size)) {
                    continue;
                }

                try {
                    // Comprimir la imagen a máx 1200px y calidad JPEG 0.75
                    const base64Comprimida = await comprimirEnCliente(file, 1200, 0.75);
                    const siguienteOrden = coleccionImagenes.length + 1;

                    coleccionImagenes.push({
                        id: 'img_' + Date.now() + '_' + Math.random().toString(36).substr(2, 5),
                        nombre: file.name,
                        tamanoOriginal: file.size,
                        base64: base64Comprimida,
                        orden: siguienteOrden
                    });
                } catch (err) {
                    console.error("Error al comprimir imagen:", file.name, err);
                }
            }

            inputImagenes.value = ""; // Limpiar input para permitir reseleccionar el mismo archivo
            renderizarPrevisualizaciones();
        });
    }

    // Función de compresión con HTML5 Canvas
    function comprimirEnCliente(archivo, anchoMaximo, calidadJpeg) {
        return new Promise((resolve, reject) => {
            const lector = new FileReader();
            lector.readAsDataURL(archivo);
            lector.onload = (evento) => {
                const img = new Image();
                img.src = evento.target.result;
                img.onload = () => {
                    let ancho = img.width;
                    let alto = img.height;

                    if (ancho > anchoMaximo) {
                        alto = Math.round((alto * anchoMaximo) / ancho);
                        ancho = anchoMaximo;
                    }

                    const canvas = document.createElement('canvas');
                    canvas.width = ancho;
                    canvas.height = alto;

                    const ctx = canvas.getContext('2d');
                    ctx.drawImage(img, 0, 0, ancho, alto);

                    // Devuelve string data:image/jpeg;base64,... liviano
                    resolve(canvas.toDataURL('image/jpeg', calidadJpeg));
                };
                img.onerror = reject;
            };
            lector.onerror = reject;
        });
    }

    // Dibuja las tarjetas y actualiza el HiddenField
    function renderizarPrevisualizaciones() {
        if (!previewsGrid) return;
        previewsGrid.innerHTML = '';

        // Ordenar el arreglo ascendentemente por su propiedad 'orden'
        coleccionImagenes.sort((a, b) => a.orden - b.orden);

        // Normalizar los órdenes para que sean correlativos (1, 2, 3...)
        coleccionImagenes.forEach((item, index) => {
            item.orden = index + 1;
        });

        coleccionImagenes.forEach((item) => {
            const esPortada = (item.orden === 1);

            const card = document.createElement('div');
            card.className = `preview-card ${esPortada ? 'es-portada' : ''}`;
            card.innerHTML = `
                <img src="${item.base64}" alt="${item.nombre}">
                <span class="badge-portada"><i class="fas fa-star"></i> Portada</span>
                <button type="button" class="preview-remove-btn" title="Eliminar"><i class="fas fa-times"></i></button>
                <div class="preview-orden-box">
                    <label>N°</label>
                    <input type="number" min="1" max="${coleccionImagenes.length}" value="${item.orden}" class="input-orden">
                </div>
            `;

            // Evento: Eliminar imagen
            card.querySelector('.preview-remove-btn').addEventListener('click', (ev) => {
                ev.stopPropagation();
                coleccionImagenes = coleccionImagenes.filter(x => x.id !== item.id);
                renderizarPrevisualizaciones();
            });

            // Evento: Modificar número de orden manualmente
            const inputOrden = card.querySelector('.input-orden');
            inputOrden.addEventListener('change', (ev) => {
                let nuevoOrden = parseInt(ev.target.value, 10);
                if (isNaN(nuevoOrden) || nuevoOrden < 1) nuevoOrden = 1;
                if (nuevoOrden > coleccionImagenes.length) nuevoOrden = coleccionImagenes.length;

                // Asignar el nuevo valor al item actual
                item.orden = nuevoOrden - 0.5; // Desempate para insertar antes del elemento destino
                renderizarPrevisualizaciones();
            });

            previewsGrid.appendChild(card);
        });

        sincronizarConServidor();
    }

    // Guarda el array serializado en el HiddenField
    function sincronizarConServidor() {
        if (!hfImagenesData) return;

        // Guardamos solo los datos necesarios para C# (orden, nombre y base64)
        const payload = coleccionImagenes.map(x => ({
            Orden: x.orden,
            Nombre: x.nombre,
            Base64: x.base64
        }));

        hfImagenesData.value = JSON.stringify(payload);
    }
});