-- phpMyAdmin SQL Dump
-- version 4.9.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Dec 08, 2019 at 08:05 AM
-- Server version: 10.4.8-MariaDB
-- PHP Version: 7.3.11

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `hospitaldb`
--

-- --------------------------------------------------------

--
-- Table structure for table `bedside`
--

CREATE TABLE `bedside` (
  `bedsideId` int(11) NOT NULL,
  `wing` varchar(20) NOT NULL,
  `floor` varchar(10) NOT NULL,
  `bay` varchar(10) NOT NULL,
  `bed` varchar(10) NOT NULL,
  `status` tinyint(1) NOT NULL,
  `patientId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `bedside`
--

INSERT INTO `bedside` (`bedsideId`, `wing`, `floor`, `bay`, `bed`, `status`, `patientId`) VALUES
(1, 'East Wing', 'Floor 1', 'Bay A', 'Bed 1', 0, 0),
(2, 'East Wing', 'Floor 1', 'Bay A', 'Bed 2', 0, 0),
(3, 'East Wing', 'Floor 1', 'Bay A', 'Bed 3', 0, 0),
(4, 'East Wing', 'Floor 1', 'Bay A', 'Bed 4', 0, 0),
(5, 'East Wing', 'Floor 1', 'Bay A', 'Bed 5', 0, 0),
(6, 'East Wing', 'Floor 1', 'Bay A', 'Bed 6', 0, 0),
(7, 'East Wing', 'Floor 1', 'Bay A', 'Bed 7', 0, 0),
(8, 'East Wing', 'Floor 1', 'Bay A', 'Bed 8', 0, 0),
(9, 'East Wing', 'Floor 1', 'Bay B', 'Bed 1', 0, 0),
(10, 'East Wing', 'Floor 1', 'Bay B', 'Bed 2', 0, 0),
(11, 'East Wing', 'Floor 1', 'Bay B', 'Bed 3', 0, 0),
(12, 'East Wing', 'Floor 1', 'Bay B', 'Bed 4', 0, 0),
(13, 'East Wing', 'Floor 1', 'Bay B', 'Bed 5', 0, 0),
(14, 'East Wing', 'Floor 1', 'Bay B', 'Bed 6', 0, 0),
(15, 'East Wing', 'Floor 1', 'Bay B', 'Bed 7', 0, 0),
(16, 'East Wing', 'Floor 1', 'Bay B', 'Bed 8', 0, 0),
(17, 'East Wing', 'Floor 2', 'Bay A', 'Bed 1', 0, 0),
(18, 'East Wing', 'Floor 2', 'Bay A', 'Bed 2', 0, 0),
(19, 'East Wing', 'Floor 2', 'Bay A', 'Bed 3', 0, 0),
(20, 'East Wing', 'Floor 2', 'Bay A', 'Bed 4', 0, 0),
(21, 'East Wing', 'Floor 2', 'Bay A', 'Bed 5', 0, 0),
(22, 'East Wing', 'Floor 2', 'Bay A', 'Bed 6', 0, 0),
(23, 'East Wing', 'Floor 2', 'Bay A', 'Bed 7', 0, 0),
(24, 'East Wing', 'Floor 2', 'Bay A', 'Bed 8', 0, 0),
(25, 'East Wing', 'Floor 2', 'Bay B', 'Bed 1', 0, 0),
(26, 'East Wing', 'Floor 2', 'Bay B', 'Bed 2', 0, 0),
(27, 'East Wing', 'Floor 2', 'Bay B', 'Bed 3', 0, 0),
(28, 'East Wing', 'Floor 2', 'Bay B', 'Bed 4', 0, 0),
(29, 'East Wing', 'Floor 2', 'Bay B', 'Bed 5', 0, 0),
(30, 'East Wing', 'Floor 2', 'Bay B', 'Bed 6', 0, 0),
(31, 'East Wing', 'Floor 2', 'Bay B', 'Bed 7', 0, 0),
(32, 'East Wing', 'Floor 2', 'Bay B', 'Bed 8', 0, 0),
(33, 'West Wing', 'Floor 1', 'Bay A', 'Bed 1', 0, 0),
(34, 'West Wing', 'Floor 1', 'Bay A', 'Bed 2', 0, 0),
(35, 'West Wing', 'Floor 1', 'Bay A', 'Bed 3', 0, 0),
(36, 'West Wing', 'Floor 1', 'Bay A', 'Bed 4', 0, 0),
(37, 'West Wing', 'Floor 1', 'Bay A', 'Bed 5', 0, 0),
(38, 'West Wing', 'Floor 1', 'Bay A', 'Bed 6', 0, 0),
(39, 'West Wing', 'Floor 1', 'Bay A', 'Bed 7', 0, 0),
(40, 'West Wing', 'Floor 1', 'Bay A', 'Bed 8', 0, 0),
(41, 'West Wing', 'Floor 1', 'Bay B', 'Bed 1', 0, 0),
(42, 'West Wing', 'Floor 1', 'Bay B', 'Bed 2', 0, 0),
(43, 'West Wing', 'Floor 1', 'Bay B', 'Bed 3', 0, 0),
(44, 'West Wing', 'Floor 1', 'Bay B', 'Bed 4', 0, 0),
(45, 'West Wing', 'Floor 1', 'Bay B', 'Bed 5', 0, 0),
(46, 'West Wing', 'Floor 1', 'Bay B', 'Bed 6', 0, 0),
(47, 'West Wing', 'Floor 1', 'Bay B', 'Bed 7', 0, 0),
(48, 'West Wing', 'Floor 1', 'Bay B', 'Bed 8', 0, 0),
(49, 'West Wing', 'Floor 2', 'Bay A', 'Bed 1', 0, 0),
(50, 'West Wing', 'Floor 2', 'Bay A', 'Bed 2', 0, 0),
(51, 'West Wing', 'Floor 2', 'Bay A', 'Bed 3', 0, 0),
(52, 'West Wing', 'Floor 2', 'Bay A', 'Bed 4', 0, 0),
(53, 'West Wing', 'Floor 2', 'Bay A', 'Bed 5', 0, 0),
(54, 'West Wing', 'Floor 2', 'Bay A', 'Bed 6', 0, 0),
(55, 'West Wing', 'Floor 2', 'Bay A', 'Bed 7', 0, 0),
(56, 'West Wing', 'Floor 2', 'Bay A', 'Bed 8', 0, 0),
(57, 'West Wing', 'Floor 2', 'Bay B', 'Bed 1', 0, 0),
(58, 'West Wing', 'Floor 2', 'Bay B', 'Bed 2', 0, 0),
(59, 'West Wing', 'Floor 2', 'Bay B', 'Bed 3', 0, 0),
(60, 'West Wing', 'Floor 2', 'Bay B', 'Bed 4', 0, 0),
(61, 'West Wing', 'Floor 2', 'Bay B', 'Bed 5', 0, 0),
(62, 'West Wing', 'Floor 2', 'Bay B', 'Bed 6', 0, 0),
(63, 'West Wing', 'Floor 2', 'Bay B', 'Bed 7', 0, 0),
(64, 'West Wing', 'Floor 2', 'Bay B', 'Bed 8', 0, 0);

-- --------------------------------------------------------

--
-- Table structure for table `medicalstaff`
--

CREATE TABLE `medicalstaff` (
  `id` int(11) NOT NULL,
  `staffId` varchar(10) NOT NULL,
  `staffName` varchar(50) NOT NULL,
  `password` varchar(25) NOT NULL,
  `careerType` varchar(20) NOT NULL,
  `email` varchar(50) NOT NULL,
  `contactNumber` varchar(15) NOT NULL,
  `pagerNumber` varchar(15) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `messages`
--

CREATE TABLE `messages` (
  `id` int(11) NOT NULL,
  `staffId` varchar(255) NOT NULL,
  `location` varchar(255) NOT NULL,
  `patient` varchar(255) NOT NULL,
  `status` varchar(255) NOT NULL,
  `dataAndTimeAlert` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `modulesreading`
--

CREATE TABLE `modulesreading` (
  `modulesReadingId` int(11) NOT NULL,
  `patientId` int(11) NOT NULL,
  `pulseRMin` int(255) NOT NULL,
  `pulseRMax` int(255) NOT NULL,
  `pulseRIntTime` int(10) NOT NULL,
  `PRmodifiedTime` varchar(255) NOT NULL,
  `breathRMin` int(255) NOT NULL,
  `breathRMax` int(255) NOT NULL,
  `breathRIntTime` int(10) NOT NULL,
  `BRmodifiedTime` varchar(255) NOT NULL,
  `systolicMin` int(255) NOT NULL,
  `systolicMax` int(255) NOT NULL,
  `diastolicMin` int(255) NOT NULL,
  `diastolicMax` int(255) NOT NULL,
  `bloodPIntTime` int(11) NOT NULL,
  `BPmodifiedTime` varchar(255) NOT NULL,
  `tempMin` float NOT NULL,
  `tempMax` float NOT NULL,
  `tempIntTime` int(10) NOT NULL,
  `TEMPmodifiedTime` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `modulesreading`
--

INSERT INTO `modulesreading` (`modulesReadingId`, `patientId`, `pulseRMin`, `pulseRMax`, `pulseRIntTime`, `PRmodifiedTime`, `breathRMin`, `breathRMax`, `breathRIntTime`, `BRmodifiedTime`, `systolicMin`, `systolicMax`, `diastolicMin`, `diastolicMax`, `bloodPIntTime`, `BPmodifiedTime`, `tempMin`, `tempMax`, `tempIntTime`, `TEMPmodifiedTime`) VALUES
(1, 1, 60, 100, 1, '11/30/2019 3:01:05 PM', 12, 20, 2, '11/30/2019 3:01:05 PM', 80, 120, 60, 80, 3, '11/30/2019 3:01:05 PM', 35.2, 36.9, 5, '11/30/2019 3:01:05 PM'),
(2, 1, 70, 110, 2, '11/30/2019 3:01:05 PM', 13, 21, 2, '11/30/2019 3:01:05 PM', 70, 110, 65, 85, 4, '11/30/2019 3:01:05 PM', 35.2, 36.9, 5, '11/30/2019 3:01:05 PM'),
(3, 1, 70, 110, 2, '11/30/2019 3:58:22 PM', 13, 21, 2, '11/30/2019 3:58:22 PM', 70, 110, 65, 85, 4, '11/30/2019 3:58:22 PM', 35.2, 36.9, 5, '11/30/2019 3:58:22 PM'),
(4, 1, 71, 110, 2, '11/30/2019 4:05:16 PM', 13, 21, 2, '11/30/2019 4:05:16 PM', 70, 110, 65, 85, 4, '11/30/2019 4:05:16 PM', 35.2, 36.9, 5, '11/30/2019 4:05:16 PM'),
(5, 2, 60, 100, 1, '11/30/2019 6:13:29 PM', 12, 21, 2, '11/30/2019 6:13:29 PM', 80, 120, 60, 80, 3, '11/30/2019 6:13:29 PM', 35.2, 36.9, 5, '11/30/2019 6:13:29 PM'),
(6, 3, 60, 100, 1, '12/8/2019 2:16:21 PM', 12, 20, 2, '12/8/2019 2:16:21 PM', 80, 120, 60, 80, 3, '12/8/2019 2:16:21 PM', 35.2, 36.9, 5, '12/8/2019 2:16:21 PM');

-- --------------------------------------------------------

--
-- Table structure for table `onshift`
--

CREATE TABLE `onshift` (
  `onShiftId` int(255) NOT NULL,
  `staffId` varchar(255) NOT NULL,
  `dateOnShift` varchar(255) NOT NULL,
  `timeOnShift` varchar(255) NOT NULL,
  `dateAndTimeRegistered` varchar(255) NOT NULL,
  `dateAndTimeDeregistered` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `patient`
--

CREATE TABLE `patient` (
  `patientId` int(11) NOT NULL,
  `patientName` varchar(50) NOT NULL,
  `patientAge` int(150) NOT NULL,
  `patientGender` varchar(10) NOT NULL,
  `bedsideId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `patientreadings`
--

CREATE TABLE `patientreadings` (
  `patientReadingId` int(11) NOT NULL,
  `patientId` int(11) NOT NULL,
  `pulseRate` int(255) NOT NULL,
  `breathingRate` int(255) NOT NULL,
  `systolic` int(255) NOT NULL,
  `diastolic` int(255) NOT NULL,
  `temperature` float NOT NULL,
  `dateAndTime` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `bedside`
--
ALTER TABLE `bedside`
  ADD PRIMARY KEY (`bedsideId`);

--
-- Indexes for table `medicalstaff`
--
ALTER TABLE `medicalstaff`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `messages`
--
ALTER TABLE `messages`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `modulesreading`
--
ALTER TABLE `modulesreading`
  ADD PRIMARY KEY (`modulesReadingId`);

--
-- Indexes for table `onshift`
--
ALTER TABLE `onshift`
  ADD PRIMARY KEY (`onShiftId`);

--
-- Indexes for table `patient`
--
ALTER TABLE `patient`
  ADD PRIMARY KEY (`patientId`);

--
-- Indexes for table `patientreadings`
--
ALTER TABLE `patientreadings`
  ADD PRIMARY KEY (`patientReadingId`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `bedside`
--
ALTER TABLE `bedside`
  MODIFY `bedsideId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=65;

--
-- AUTO_INCREMENT for table `medicalstaff`
--
ALTER TABLE `medicalstaff`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `messages`
--
ALTER TABLE `messages`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `modulesreading`
--
ALTER TABLE `modulesreading`
  MODIFY `modulesReadingId` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `onshift`
--
ALTER TABLE `onshift`
  MODIFY `onShiftId` int(255) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `patient`
--
ALTER TABLE `patient`
  MODIFY `patientId` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `patientreadings`
--
ALTER TABLE `patientreadings`
  MODIFY `patientReadingId` int(11) NOT NULL AUTO_INCREMENT;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
