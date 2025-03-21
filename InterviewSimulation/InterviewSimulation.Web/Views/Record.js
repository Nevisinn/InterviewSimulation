let mediaRecorder;
let audioChunks = [];

const startButton = document.getElementById('start-btn');
const stopButton = document.getElementById('stop-btn');
const transcriptionField = document.getElementById('transcription');

// Запрос доступа к микрофону и настройка MediaRecorder
startButton.addEventListener('click', async () => {
    const stream = await navigator.mediaDevices.getUserMedia({ audio: true });
    mediaRecorder = new MediaRecorder(stream);

    mediaRecorder.ondataavailable = (event) => {
        audioChunks.push(event.data);
    };

    console.log(MediaRecorder.isTypeSupported('audio/webm'));
    console.log(MediaRecorder.isTypeSupported('audio/ogg'));
    console.log(MediaRecorder.isTypeSupported('audio/wav'));
    
    mediaRecorder.onstop = () => {
        const audioBlob = new Blob(audioChunks, { type: 'audio/webm' });
        audioChunks = [];
        sendAudioToServer(audioBlob);
    };

    mediaRecorder.start();
    startButton.disabled = true;
    stopButton.disabled = false;

    // Ограничиваем запись 15 секундами
    recordingTimeout = setTimeout(() => {
        if (mediaRecorder.state === "recording") {
            mediaRecorder.stop();
            startButton.disabled = false;
            stopButton.disabled = true;
        }
    }, 15000);
});

// Остановка записи
stopButton.addEventListener('click', () => {
    clearTimeout(recordingTimeout);
    mediaRecorder.stop();
    startButton.disabled = false;
    stopButton.disabled = true;
});



async function sendAudioToServer(audioBlob) {
    const formData = new FormData();
    formData.append('audio', audioBlob);

    try {
        const response = await fetch('https://localhost:7046/api/speech-to-text', {
            method: 'POST',
            body: formData,
        });

        if (response.ok) {
            const result = await response.json();
            transcriptionField.textContent = result.transcription || 'Нет текста';
        } else {
            transcriptionField.textContent = 'Ошибка распознавания';
        }
    } catch (error) {
        console.error('Ошибка при отправке аудио:', error);
        transcriptionField.textContent = 'Ошибка при соединении с сервером';
    }
}