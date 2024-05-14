 // JavaScript kodları buraya gelecek
 const imageList = document.getElementById('imageList');
 const scrollbar = document.getElementById('scrollbar');
 const scrollbarThumb = document.querySelector('.scrollbar-thumb');
 let isDragging = false;

 function moveSlider(direction) {
     const step = 325; // Bir resmin genişliği
     const currentPosition = imageList.scrollLeft;

     if (direction === 'left') {
         imageList.scrollTo({
             left: currentPosition - step,
             behavior: 'smooth'
         });
     } else if (direction === 'right') {
         imageList.scrollTo({
             left: currentPosition + step,
             behavior: 'smooth'
         });
     }
 }

 function startDrag(e) {
     isDragging = true;
     document.addEventListener('mousemove', drag);
     document.addEventListener('mouseup', stopDrag);
 }

 function drag(e) {
     if (!isDragging) return;

     const { left: scrollbarLeft, width: scrollbarWidth } = scrollbar.getBoundingClientRect();
     const { width: thumbWidth } = scrollbarThumb.getBoundingClientRect();

     let newX = e.clientX - scrollbarLeft - thumbWidth / 2;
     const maxWidth = scrollbarWidth - thumbWidth;

     newX = Math.max(0, Math.min(newX, maxWidth));

     const percent = newX / maxWidth;
     const maxScrollLeft = imageList.scrollWidth - imageList.clientWidth;

     imageList.scrollTo({
         left: maxScrollLeft * percent,
         behavior: 'auto'
     });

     scrollbarThumb.style.left = newX + 'px';
 }

 function stopDrag() {
     isDragging = false;
     document.removeEventListener('mousemove', drag);
     document.removeEventListener('mouseup', stopDrag);
 }