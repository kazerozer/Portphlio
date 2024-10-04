-- phpMyAdmin SQL Dump
-- version 3.5.1
-- http://www.phpmyadmin.net
--
-- Хост: 127.0.0.1
-- Время создания: Фев 07 2024 г., 15:57
-- Версия сервера: 5.5.25
-- Версия PHP: 5.3.13

SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- База данных: `telefon`
--
CREATE DATABASE `telefon` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;
USE `telefon`;

-- --------------------------------------------------------

--
-- Структура таблицы `contacts`
--

CREATE TABLE IF NOT EXISTS `contacts` (
  `id` int(20) NOT NULL AUTO_INCREMENT,
  `fio` text,
  `tel` text,
  `kto` text,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=48 ;

--
-- Дамп данных таблицы `contacts`
--

INSERT INTO `contacts` (`id`, `fio`, `tel`, `kto`) VALUES
(45, 'Беркутов Дмитрий Михайлович', '8 (908) 654-52-36', 'Водитель'),
(46, 'Михалков Валерий Степанович', '8 (922) 546-87-96', 'Механик'),
(47, 'Дергунов Евгений Викторович', '8 (911) 258-65-41', 'Директор');

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
