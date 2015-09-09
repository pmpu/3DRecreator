﻿# 3DRecreator


Основная задача:
Создание клиент-серверного приложения с интуитивно понятным интерфейсом, преобразующего видеоматериал, содержащий некоторый объект, в облако точек, на основе которого строится трёхмерная модель данного объекта с дальнейшей возможностью покрытия полученной модели различными текстурами и субстанциями по выбору пользователя.
<br />
Предполагается разбить конечную задачу на более мелкие подзадачи: 
<br />

<ul>
<li>Разработка клиентского приложения
	<ul>
	<li>Распознавание на модели границ текстур. В будущем планируется создание простейшего графического редактора для ручной прорисовки границ, однако на данный момент распознавание будет осуществляться в автоматическом режиме.</li>
	<li>Создание библиотеки текстур</li>
	<li>Функция подмены текстур, позволяющая пользователю заменять область на модели некоторой текстурой из библиотеки</li>
	</ul>
</li>
<li>Разработка серверного приложения
	<ul>
	<li>Раскадровка видео</li>
	<li>Создание облака точек на основе ряда картинок</li>
	<li>Построение модели по облаку точек</li>
	</ul>
</li>
</ul>
<br />
<br />
Что на данный момент готово (в дальнейшем будет добавлено в репозиторий):
<ul>
	<li>Нод, позволяющий смешивать до 31 различного материала в одной текстуре, созданный средствами Substance Designer. Необходим для работы с подменой текстур.</li>
	<li>Код, постеризующий изображение (имеется два варианта, требует доработки). Написан с использованием OpenCV. Необходим для автоатического распознавания границ текстур.</li>
	<li>Часть интерфейса клиентского приложения, требующая доработки. Есть возможность выбора одной текстуры для объекта. Написано с использованием Unity3D.</li>

</ul>

<br />
С чем нам предстоит работать:
<br />
<a align="left" href="https://github.com/openMVG/openMVG/"> OpenMVG </a>
<br />
<a align="left" href="https://github.com/PixarAnimationStudios/OpenSubdiv"> OpenSubdiv </a>
<br />
<a align="left" href="http://www.openvdb.org/"> OpenVDB </a>
<br />
<a align="left" href="http://opencv.org/"> OpenCV </a>
<br />
<a align="left" href="http://pointclouds.org/"> PCL </a>
<br />
Unity3D
<br />
Substance Designer
<br />



