let canvas, context;

window.initSignaturePad = () => {
    canvas = document.getElementById('signature-pad');
    context = canvas.getContext('2d');

    let drawing = false;

    canvas.onmousedown = e => {
        drawing = true;
        context.beginPath();
        context.moveTo(e.offsetX, e.offsetY);
    };

    canvas.onmousemove = e => {
        if (drawing) {
            context.lineTo(e.offsetX, e.offsetY);
            context.stroke();
        }
    };

    canvas.onmouseup = () => {
        drawing = false;
    };

    canvas.ontouchstart = e => {
        e.preventDefault();
        drawing = true;
        const rect = canvas.getBoundingClientRect();
        const touch = e.touches[0];
        context.beginPath();
        context.moveTo(touch.clientX - rect.left, touch.clientY - rect.top);
    };

    canvas.ontouchmove = e => {
        e.preventDefault();
        if (drawing) {
            const rect = canvas.getBoundingClientRect();
            const touch = e.touches[0];
            context.lineTo(touch.clientX - rect.left, touch.clientY - rect.top);
            context.stroke();
        }
    };

    canvas.ontouchend = () => {
        drawing = false;
    };
};

window.clearSignaturePad = () => {
    context.clearRect(0, 0, canvas.width, canvas.height);
};

window.getSignatureImage = () => {
    return canvas.toDataURL("image/png");
};
