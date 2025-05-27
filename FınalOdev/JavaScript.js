let currentSlide = 0;

function showSlide(index) {
    const slides = document.querySelector('.slides');
    if (!slides) return; 

    const totalSlides = slides.children.length;
    currentSlide = (index + totalSlides) % totalSlides;
    slides.style.transform = `translateX(-${currentSlide * 100}%)`;
}

setInterval(() => {
    showSlide(currentSlide + 1);
}, 3000);

function animateOnScroll() {
    const elements = document.querySelectorAll('.animate-on-scroll');
    const triggerBottom = window.innerHeight * 0.9;

    elements.forEach((el) => {
        const boxTop = el.getBoundingClientRect().top;
        if (boxTop < triggerBottom) {
            el.classList.add('show');
        } else {
            el.classList.remove('show');
        }
    });
}

window.addEventListener('scroll', animateOnScroll);

document.addEventListener('DOMContentLoaded', () => {
    animateOnScroll();
    showSlide(0); 
});
