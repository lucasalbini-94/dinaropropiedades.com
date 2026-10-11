// ==========================================
// 1. COMPORTAMIENTO GLOBAL (MENÚ LATERAL Y SUBMENÚS)
// ==========================================
document.addEventListener('DOMContentLoaded', () => {
    // Submenús acordeón en la barra lateral
    const menuLinksWithSubmenu = document.querySelectorAll('.menu-item > .menu-link');
    menuLinksWithSubmenu.forEach(link => {
        const submenu = link.nextElementSibling;
        const arrow = link.querySelector('.fa-chevron-down');

        if (submenu && submenu.classList.contains('submenu')) {
            if (arrow) arrow.style.transition = 'transform 0.3s ease';

            link.addEventListener('click', (e) => {
                e.preventDefault();
                const isOpen = submenu.style.maxHeight && submenu.style.maxHeight !== '0px';

                // Cerrar otros submenús
                document.querySelectorAll('.submenu').forEach(otherSubmenu => {
                    if (otherSubmenu !== submenu && otherSubmenu.style.maxHeight) {
                        otherSubmenu.style.maxHeight = null;
                        const otherLink = otherSubmenu.previousElementSibling;
                        const otherArrow = otherLink ? otherLink.querySelector('.fa-chevron-down') : null;
                        if (otherArrow) otherArrow.style.transform = 'rotate(0deg)';
                    }
                });

                // Alternar actual
                if (isOpen) {
                    submenu.style.maxHeight = null;
                    if (arrow) arrow.style.transform = 'rotate(0deg)';
                } else {
                    submenu.style.maxHeight = submenu.scrollHeight + 'px';
                    if (arrow) arrow.style.transform = 'rotate(180deg)';
                }
            });
        }
    });

    // Menú hamburguesa responsive (Aside)
    const menuToggle = document.getElementById('menu-toggle');
    const sidebar = document.querySelector('aside');

    if (menuToggle && sidebar) {
        menuToggle.addEventListener('click', (e) => {
            e.preventDefault();
            e.stopPropagation();
            sidebar.classList.toggle('active');
        });

        document.addEventListener('click', (e) => {
            if (!sidebar.contains(e.target) && !menuToggle.contains(e.target) && sidebar.classList.contains('active')) {
                sidebar.classList.remove('active');
            }
        });
    }

    // Inicializar tabla si existe en la página
    inicializarTabla();
});

// ==========================================
// 2. TABLA RESPONSIVE Y PAGINACIÓN
// ==========================================
function inicializarTabla() {
    const tabla = document.getElementById('tablaInmuebles');
    if (!tabla) return; // Si la página actual no tiene la tabla, no hace nada

    const tbody = document.getElementById('tablaBody');
    const selectRegistros = document.getElementById('registrosPorPagina');
    const paginacionContainer = document.getElementById('paginacionContainer');

    if (!tbody) return;
    const filas = Array.from(tbody.querySelectorAll('tr.propiedad-row'));
    if (filas.length === 0) return;

    let paginaActual = 1;
    let registrosPorPagina = selectRegistros ? parseInt(selectRegistros.value, 10) : 10;

    function renderizarTabla() {
        const esMobile = window.innerWidth <= 850;

        // En pantallas móviles (< 850px) se muestran todas para permitir ver las tarjetas
        if (esMobile) {
            filas.forEach(fila => fila.style.display = '');
            if (paginacionContainer) paginacionContainer.innerHTML = '';
            return;
        }

        // En pantallas de escritorio se aplica la paginación seleccionada
        const totalPaginas = Math.ceil(filas.length / registrosPorPagina) || 1;
        if (paginaActual > totalPaginas) paginaActual = totalPaginas;

        const inicio = (paginaActual - 1) * registrosPorPagina;
        const fin = inicio + registrosPorPagina;

        filas.forEach((fila, i) => {
            if (i >= inicio && i < fin) {
                fila.style.display = '';
            } else {
                fila.style.display = 'none';
                fila.classList.remove('abierta');
            }
        });

        renderizarControlesPaginacion(totalPaginas);
    }

    function renderizarControlesPaginacion(totalPaginas) {
        if (!paginacionContainer) return;
        paginacionContainer.innerHTML = '';
        if (totalPaginas <= 1) return;

        // Botón Anterior
        const btnPrev = document.createElement('button');
        btnPrev.type = 'button';
        btnPrev.className = 'btn-pagina';
        btnPrev.innerHTML = '<i class="fas fa-chevron-left"></i>';
        btnPrev.disabled = paginaActual === 1;
        btnPrev.addEventListener('click', () => {
            if (paginaActual > 1) {
                paginaActual--;
                renderizarTabla();
            }
        });
        paginacionContainer.appendChild(btnPrev);

        // Números de Página
        for (let i = 1; i <= totalPaginas; i++) {
            const btnPagina = document.createElement('button');
            btnPagina.type = 'button';
            btnPagina.className = `btn-pagina ${i === paginaActual ? 'activo' : ''}`;
            btnPagina.innerText = i;
            btnPagina.addEventListener('click', () => {
                paginaActual = i;
                renderizarTabla();
            });
            paginacionContainer.appendChild(btnPagina);
        }

        // Botón Siguiente
        const btnNext = document.createElement('button');
        btnNext.type = 'button';
        btnNext.className = 'btn-pagina';
        btnNext.innerHTML = '<i class="fas fa-chevron-right"></i>';
        btnNext.disabled = paginaActual === totalPaginas;
        btnNext.addEventListener('click', () => {
            if (paginaActual < totalPaginas) {
                paginaActual++;
                renderizarTabla();
            }
        });
        paginacionContainer.appendChild(btnNext);
    }

    if (selectRegistros) {
        selectRegistros.onchange = () => {
            registrosPorPagina = parseInt(selectRegistros.value, 10);
            paginaActual = 1;
            renderizarTabla();
        };
    }

    // Delegación ÚNICA de clic para tarjetas móviles (<= 850px)
    tbody.onclick = function (e) {
        if (window.innerWidth <= 850) {
            // No hacer nada si se hace clic en botones de Editar, Eliminar o QR
            if (e.target.closest('.btn') || e.target.closest('a') || e.target.closest('button')) {
                return;
            }

            const fila = e.target.closest('.propiedad-row');
            if (fila) {
                // Modo acordeón: cerrar las demás tarjetas
                filas.forEach(otraFila => {
                    if (otraFila !== fila) {
                        otraFila.classList.remove('abierta');
                    }
                });

                fila.classList.toggle('abierta');
            }
        }
    };

    window.onresize = renderizarTabla;
    renderizarTabla();
}

// Función nativa de ASP.NET que se ejecuta tras postbacks de Web Forms
function pageLoad() {
    inicializarTabla();
}