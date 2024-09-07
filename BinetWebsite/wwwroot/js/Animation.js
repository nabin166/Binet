
document.addEventListener('DOMContentLoaded', () => {
    const sections = document.querySelectorAll('.slide-top');

    const handleScroll = () => {
        sections.forEach(section => {
            const rect = section.getBoundingClientRect();
            const viewportHeight = window.innerHeight || document.documentElement.clientHeight;

            if (rect.top < viewportHeight && rect.bottom > 0) {
                section.classList.add('animate');
            }
        });
    };

    window.addEventListener('scroll', handleScroll);
    handleScroll(); // Initial check in case elements are already in view
});


