const menuBtn = document.getElementById('hamburger');
const navList = document.getElementById('nav-list');

menuBtn.addEventListener('click', () => {
    navList.classList.toggle('active');
});

const slides = document.querySelectorAll('.carousel-item');
const prevBtn = document.querySelector('.carousel-control.prev');
const nextBtn = document.querySelector('.carousel-control.next');
const dotsContainer = document.querySelector('.carousel-dots');
let currentIndex = 0;
let slideInterval;

function createDots() {
    slides.forEach((_, index) => {
        const dot = document.createElement('button');
        dot.addEventListener('click', () => {
            showSlide(index);
            resetSlideInterval();
        });
        dotsContainer.appendChild(dot);
    });
}

function updateDots() {
    const dots = dotsContainer.querySelectorAll('button');
    dots.forEach((dot, index) => {
        dot.classList.toggle('active', index === currentIndex);
    });
}

function showSlide(index) {
    currentIndex = (index + slides.length) % slides.length;
    slides.forEach((slide, slideIndex) => {
        slide.classList.toggle('active', slideIndex === currentIndex);
    });
    updateDots();
}

function nextSlide() {
    showSlide(currentIndex + 1);
}

function prevSlide() {
    showSlide(currentIndex - 1);
}

function startSlideInterval() {
    slideInterval = setInterval(nextSlide, 5000);
}

function resetSlideInterval() {
    clearInterval(slideInterval);
    startSlideInterval();
}

if (slides.length > 0) {
    createDots();
    showSlide(0);
    startSlideInterval();
}

if (prevBtn && nextBtn) {
    prevBtn.addEventListener('click', () => {
        prevSlide();
        resetSlideInterval();
    });

    nextBtn.addEventListener('click', () => {
        nextSlide();
        resetSlideInterval();
    });
}

function filterChange(clickedBtn) {
    // Remover clase active de todos los botones
    const tabBtns = document.querySelectorAll('.tab-btn');
    tabBtns.forEach(btn => btn.classList.remove('active'));

    // Agregar clase active al botón clicado
    clickedBtn.classList.add('active');

    // Mostrar/ocultar filtros según el botón seleccionado
    const propiedadesFilter = document.getElementById('propiedades-filter');
    const terrenosFilter = document.getElementById('terrenos-filter');

    if (clickedBtn.textContent.trim() === 'PROPIEDADES') {
        propiedadesFilter.style.display = 'flex';
        terrenosFilter.style.display = 'none';
    } else if (clickedBtn.textContent.trim() === 'TERRENOS') {
        propiedadesFilter.style.display = 'none';
        terrenosFilter.style.display = 'flex';
    }
}

function scrollDerecha() {
    const container = document.querySelector('.cards-container');
    const card = document.querySelector('.property-card');
    const cardWidth = card.offsetWidth;
    const gap = parseInt(getComputedStyle(container).gap) || 25;
    const scrollAmount = cardWidth + gap;
    container.scrollBy({
        left: scrollAmount,
        behavior: 'smooth'
    });
}

function scrollIzquierda() {
    const container = document.querySelector('.cards-container');
    const card = document.querySelector('.property-card');
    const cardWidth = card.offsetWidth;
    const gap = parseInt(getComputedStyle(container).gap) || 25;
    const scrollAmount = cardWidth + gap;
    container.scrollBy({
        left: -scrollAmount,
        behavior: 'smooth'
    });
}