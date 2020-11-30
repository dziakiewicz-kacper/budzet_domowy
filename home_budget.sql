-- phpMyAdmin SQL Dump
-- version 5.0.4
-- https://www.phpmyadmin.net/
--
-- Host: db
-- Czas generowania: 30 Lis 2020, 08:14
-- Wersja serwera: 8.0.22
-- Wersja PHP: 7.4.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Baza danych: `home_budget`
--

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `account`
--

CREATE TABLE `account` (
  `id` int NOT NULL,
  `login` varchar(20) NOT NULL,
  `password` varchar(30) NOT NULL,
  `mode` enum('user','admin') NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Zrzut danych tabeli `account`
--

INSERT INTO `account` (`id`, `login`, `password`, `mode`) VALUES
(1, 'adam', 'nowak', 'admin'),
(2, 'wojnicki@gmail.com', 'Warszawa', 'user'),
(3, 'piotrek@gmail.com', 'Olsztyn', 'user'),
(4, 'ibra.gro@gmail.com', 'ibra.gro@gmail.com', 'user');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `address`
--

CREATE TABLE `address` (
  `id` int NOT NULL,
  `id_person` int NOT NULL,
  `street` varchar(50) NOT NULL,
  `zip_code` varchar(10) NOT NULL,
  `number` varchar(20) NOT NULL,
  `town` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Zrzut danych tabeli `address`
--

INSERT INTO `address` (`id`, `id_person`, `street`, `zip_code`, `number`, `town`) VALUES
(1, 1, 'Radosna', '30a', '55-123', 'Poznań'),
(5, 2, 'Wesola', '123-33', '12a', 'Warszawa'),
(6, 3, 'Pakatna', '32-111', '30a', 'Olsztyn'),
(7, 4, 'Szkolna', '87-122', '12a', 'Wrocław');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `budget`
--

CREATE TABLE `budget` (
  `id` int NOT NULL,
  `id_account` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Zrzut danych tabeli `budget`
--

INSERT INTO `budget` (`id`, `id_account`) VALUES
(1, 1),
(4, 2),
(5, 3),
(6, 4);

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `cost`
--

CREATE TABLE `cost` (
  `id` int NOT NULL,
  `id_budget` int NOT NULL,
  `value` int NOT NULL,
  `category` enum('None','Fixed','Bills','Shopping','Food','Clothes','Entertainment','Alcohol','Other') NOT NULL DEFAULT 'None',
  `date` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Zrzut danych tabeli `cost`
--

INSERT INTO `cost` (`id`, `id_budget`, `value`, `category`, `date`) VALUES
(1, 1, 323, 'Shopping', '2020-11-09');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `goal`
--

CREATE TABLE `goal` (
  `id` int NOT NULL,
  `id_account` int NOT NULL,
  `value` int NOT NULL,
  `status` enum('None','Active','Inactive','Achived','Deleted') NOT NULL,
  `date` int DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `income`
--

CREATE TABLE `income` (
  `id` int NOT NULL,
  `id_budget` int NOT NULL,
  `value` int NOT NULL,
  `category` enum('None','Work','SellProduct','SellService','Savings','Other') NOT NULL DEFAULT 'None',
  `date` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Zrzut danych tabeli `income`
--

INSERT INTO `income` (`id`, `id_budget`, `value`, `category`, `date`) VALUES
(1, 1, 643, 'None', '2020-05-05');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `person`
--

CREATE TABLE `person` (
  `id` int NOT NULL,
  `id_account` int NOT NULL,
  `first_name` varchar(20) NOT NULL,
  `last_name` varchar(20) NOT NULL,
  `date_of_birth` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Zrzut danych tabeli `person`
--

INSERT INTO `person` (`id`, `id_account`, `first_name`, `last_name`, `date_of_birth`) VALUES
(1, 1, 'Alan', 'Gordon', '2020-11-13'),
(2, 2, 'Jerzy', 'Wojnicki', '1990-12-12'),
(3, 3, 'Piotr', 'Piotrkowski', '1990-12-12'),
(4, 4, 'Ibraham', 'Goździcki', '1990-12-12');

--
-- Indeksy dla zrzutów tabel
--

--
-- Indeksy dla tabeli `account`
--
ALTER TABLE `account`
  ADD PRIMARY KEY (`id`);

--
-- Indeksy dla tabeli `address`
--
ALTER TABLE `address`
  ADD PRIMARY KEY (`id`),
  ADD KEY `id_person` (`id_person`);

--
-- Indeksy dla tabeli `budget`
--
ALTER TABLE `budget`
  ADD PRIMARY KEY (`id`),
  ADD KEY `id_account` (`id_account`);

--
-- Indeksy dla tabeli `cost`
--
ALTER TABLE `cost`
  ADD PRIMARY KEY (`id`),
  ADD KEY `id_budget` (`id_budget`);

--
-- Indeksy dla tabeli `goal`
--
ALTER TABLE `goal`
  ADD PRIMARY KEY (`id`),
  ADD KEY `id_account` (`id_account`);

--
-- Indeksy dla tabeli `income`
--
ALTER TABLE `income`
  ADD PRIMARY KEY (`id`),
  ADD KEY `id_budget` (`id_budget`);

--
-- Indeksy dla tabeli `person`
--
ALTER TABLE `person`
  ADD PRIMARY KEY (`id`),
  ADD KEY `id_account` (`id_account`);

--
-- AUTO_INCREMENT dla zrzuconych tabel
--

--
-- AUTO_INCREMENT dla tabeli `account`
--
ALTER TABLE `account`
  MODIFY `id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=52;

--
-- AUTO_INCREMENT dla tabeli `address`
--
ALTER TABLE `address`
  MODIFY `id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT dla tabeli `budget`
--
ALTER TABLE `budget`
  MODIFY `id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT dla tabeli `cost`
--
ALTER TABLE `cost`
  MODIFY `id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT dla tabeli `goal`
--
ALTER TABLE `goal`
  MODIFY `id` int NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT dla tabeli `income`
--
ALTER TABLE `income`
  MODIFY `id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT dla tabeli `person`
--
ALTER TABLE `person`
  MODIFY `id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=85;

--
-- Ograniczenia dla zrzutów tabel
--

--
-- Ograniczenia dla tabeli `address`
--
ALTER TABLE `address`
  ADD CONSTRAINT `address_ibfk_1` FOREIGN KEY (`id_person`) REFERENCES `person` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Ograniczenia dla tabeli `budget`
--
ALTER TABLE `budget`
  ADD CONSTRAINT `budget_ibfk_1` FOREIGN KEY (`id_account`) REFERENCES `account` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Ograniczenia dla tabeli `cost`
--
ALTER TABLE `cost`
  ADD CONSTRAINT `cost_ibfk_1` FOREIGN KEY (`id_budget`) REFERENCES `budget` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Ograniczenia dla tabeli `goal`
--
ALTER TABLE `goal`
  ADD CONSTRAINT `goal_ibfk_1` FOREIGN KEY (`id_account`) REFERENCES `account` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Ograniczenia dla tabeli `income`
--
ALTER TABLE `income`
  ADD CONSTRAINT `income_ibfk_1` FOREIGN KEY (`id_budget`) REFERENCES `budget` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Ograniczenia dla tabeli `person`
--
ALTER TABLE `person`
  ADD CONSTRAINT `person_ibfk_1` FOREIGN KEY (`id_account`) REFERENCES `account` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
