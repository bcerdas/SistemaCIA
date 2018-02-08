-- phpMyAdmin SQL Dump
-- version 4.6.5.2
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 08-02-2018 a las 12:14:18
-- Versión del servidor: 10.1.21-MariaDB
-- Versión de PHP: 5.6.30

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `sistemaciadb`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `academias`
--

CREATE TABLE `academias` (
  `codigoAcademias` int(11) NOT NULL,
  `Nombre` varchar(100) COLLATE utf8_spanish_ci NOT NULL,
  `fecha` datetime NOT NULL,
  `cantNiveles` int(11) DEFAULT NULL,
  `asistencia` int(11) DEFAULT NULL,
  `montoIngreso` int(11) DEFAULT NULL,
  `montoSalida` int(11) DEFAULT NULL,
  `total` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

--
-- Volcado de datos para la tabla `academias`
--

INSERT INTO `academias` (`codigoAcademias`, `Nombre`, `fecha`, `cantNiveles`, `asistencia`, `montoIngreso`, `montoSalida`, `total`) VALUES
(10, 'prueba con codigoAcademiaNivel 2', '2018-02-07 00:00:00', 3, 6, 10000, 0, 10000);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `academiasabono`
--

CREATE TABLE `academiasabono` (
  `codigoAcademiaAbono` int(11) NOT NULL,
  `codigoAcademiasMatricula` int(11) NOT NULL,
  `abono` int(11) NOT NULL,
  `fecha` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

--
-- Volcado de datos para la tabla `academiasabono`
--

INSERT INTO `academiasabono` (`codigoAcademiaAbono`, `codigoAcademiasMatricula`, `abono`, `fecha`) VALUES
(19, 16, 2000, '2018-02-07 23:19:42'),
(20, 17, 5000, '2018-02-07 23:20:15'),
(21, 21, 3000, '2018-02-08 01:10:36');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `academiaslecciones`
--

CREATE TABLE `academiaslecciones` (
  `codigoAcademiaLeccion` int(11) NOT NULL,
  `codigoAcademias` int(11) NOT NULL,
  `codigoAcademiaNivel` int(11) DEFAULT NULL,
  `codigoMaestro` varchar(15) COLLATE utf8_spanish_ci DEFAULT NULL,
  `codigoLeccion` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

--
-- Volcado de datos para la tabla `academiaslecciones`
--

INSERT INTO `academiaslecciones` (`codigoAcademiaLeccion`, `codigoAcademias`, `codigoAcademiaNivel`, `codigoMaestro`, `codigoLeccion`) VALUES
(33, 10, 21, 'CER-123', 13),
(34, 10, 21, 'CER-123', 14),
(35, 10, 21, 'CER-123', 15),
(36, 10, 21, 'CER-123', 16),
(37, 10, 21, 'CER-123', 17),
(38, 10, 21, 'CER-123', 18),
(39, 10, 22, 'AN-100', 43),
(40, 10, 22, 'AN-100', 44),
(41, 10, 22, 'AN-100', 45),
(42, 10, 22, 'AN-100', 46),
(43, 10, 22, 'AN-100', 47),
(44, 10, 22, 'AN-100', 48),
(45, 10, 23, 'f10d2a3a-9b96-4', 63),
(46, 10, 26, 'f10d2a3a-9b96-4', 13),
(47, 10, 26, 'f10d2a3a-9b96-4', 14),
(48, 10, 26, 'CER-123', 15),
(49, 10, 26, 'AN-100', 16),
(50, 10, 26, 'CER-123', 17),
(51, 10, 26, 'f10d2a3a-9b96-4', 18);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `academiasmatriculas`
--

CREATE TABLE `academiasmatriculas` (
  `codigoAcademiaMatricula` int(11) NOT NULL,
  `codigoAcademias` int(11) NOT NULL,
  `codigoAcademiaNivel` int(11) DEFAULT NULL,
  `codigoPersona` varchar(15) COLLATE utf8_spanish_ci NOT NULL,
  `codigoNivel` int(11) NOT NULL,
  `observaciones` varchar(500) COLLATE utf8_spanish_ci DEFAULT NULL,
  `saldo` int(11) NOT NULL,
  `abono` int(11) NOT NULL,
  `becado` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

--
-- Volcado de datos para la tabla `academiasmatriculas`
--

INSERT INTO `academiasmatriculas` (`codigoAcademiaMatricula`, `codigoAcademias`, `codigoAcademiaNivel`, `codigoPersona`, `codigoNivel`, `observaciones`, `saldo`, `abono`, `becado`) VALUES
(16, 10, 21, '72786524-d747-4', 3, NULL, 1000, 2000, 1),
(17, 10, 23, 'AN-100', 13, NULL, 1000, 5000, 0),
(18, 10, 22, '606ce9d7-96d8-4', 8, NULL, 6000, 0, 0),
(19, 10, 23, 'ka12345', 13, NULL, 6000, 0, 0),
(20, 10, 21, 'ME-44444', 3, NULL, 6000, 0, 0),
(21, 10, 23, 'AND-1234', 13, NULL, 3000, 3000, 0);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `academiasniveles`
--

CREATE TABLE `academiasniveles` (
  `codigoAcademiasNiveles` int(11) NOT NULL,
  `codigoAcademias` int(11) NOT NULL,
  `codigoNivel` int(11) NOT NULL,
  `grupo` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

--
-- Volcado de datos para la tabla `academiasniveles`
--

INSERT INTO `academiasniveles` (`codigoAcademiasNiveles`, `codigoAcademias`, `codigoNivel`, `grupo`) VALUES
(21, 10, 3, 1),
(22, 10, 8, 1),
(23, 10, 13, 1),
(26, 10, 3, 2);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `areasdeministerio`
--

CREATE TABLE `areasdeministerio` (
  `codigoArea` int(11) NOT NULL,
  `codigoMinisterio` int(11) NOT NULL,
  `nombre` varchar(40) COLLATE utf8_spanish_ci NOT NULL,
  `objetivo` varchar(500) COLLATE utf8_spanish_ci NOT NULL,
  `cantMiembros` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `boletasconsolidacion`
--

CREATE TABLE `boletasconsolidacion` (
  `codigoBoleta` int(11) NOT NULL,
  `personaAsignada` varchar(15) COLLATE utf8_spanish_ci NOT NULL,
  `fecha` datetime NOT NULL,
  `actividad` varchar(50) COLLATE utf8_spanish_ci NOT NULL,
  `nombre` varchar(20) COLLATE utf8_spanish_ci NOT NULL,
  `apellido1` varchar(20) COLLATE utf8_spanish_ci NOT NULL,
  `apellido2` varchar(20) COLLATE utf8_spanish_ci DEFAULT NULL,
  `direccion` varchar(500) COLLATE utf8_spanish_ci NOT NULL,
  `edad` int(11) NOT NULL,
  `sexo` varchar(10) COLLATE utf8_spanish_ci DEFAULT NULL,
  `telefonoCasa` varchar(15) COLLATE utf8_spanish_ci DEFAULT NULL,
  `telefonoMovil` varchar(15) COLLATE utf8_spanish_ci DEFAULT NULL,
  `tipoBoleta` varchar(15) COLLATE utf8_spanish_ci DEFAULT NULL,
  `invitadoPor` varchar(70) COLLATE utf8_spanish_ci DEFAULT NULL,
  `celulaDe` varchar(15) COLLATE utf8_spanish_ci DEFAULT NULL,
  `peticion` varchar(500) COLLATE utf8_spanish_ci DEFAULT NULL,
  `llenadoPor` varchar(15) COLLATE utf8_spanish_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `celulas`
--

CREATE TABLE `celulas` (
  `codigoCelula` varchar(15) COLLATE utf8_spanish_ci NOT NULL,
  `lider` varchar(15) COLLATE utf8_spanish_ci NOT NULL,
  `asistente` varchar(15) COLLATE utf8_spanish_ci DEFAULT NULL,
  `celulaRaiz` varchar(15) COLLATE utf8_spanish_ci DEFAULT NULL,
  `lugar` varchar(40) COLLATE utf8_spanish_ci NOT NULL,
  `direccion` varchar(500) COLLATE utf8_spanish_ci DEFAULT NULL,
  `hora` varchar(10) COLLATE utf8_spanish_ci NOT NULL,
  `dia` varchar(10) COLLATE utf8_spanish_ci NOT NULL,
  `promedioPersonas` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

--
-- Volcado de datos para la tabla `celulas`
--

INSERT INTO `celulas` (`codigoCelula`, `lider`, `asistente`, `celulaRaiz`, `lugar`, `direccion`, `hora`, `dia`, `promedioPersonas`) VALUES
('35fa6479-5ac4-4', 'ka12345', 'ka12345', NULL, 'Tres Rios', 'De el parque central 100mts este.', '06 : 30 pm', 'Sábado', 0);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `celulaspersonas`
--

CREATE TABLE `celulaspersonas` (
  `codigoCelulasPersonas` int(11) NOT NULL,
  `codigoPersona` varchar(15) COLLATE utf8_spanish_ci NOT NULL,
  `codigoCelula` varchar(15) COLLATE utf8_spanish_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `chatmensajes`
--

CREATE TABLE `chatmensajes` (
  `codigoChatMensajes` int(11) NOT NULL,
  `persona1` varchar(15) COLLATE utf8_spanish_ci DEFAULT NULL,
  `persona2` varchar(15) COLLATE utf8_spanish_ci DEFAULT NULL,
  `mensaje` varchar(3000) COLLATE utf8_spanish_ci NOT NULL,
  `fecha` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `cumbrelideres`
--

CREATE TABLE `cumbrelideres` (
  `codigoCumbreLideres` int(11) NOT NULL,
  `nombre` varchar(70) COLLATE utf8_spanish_ci NOT NULL,
  `lema` varchar(50) COLLATE utf8_spanish_ci DEFAULT NULL,
  `objetivo` varchar(400) COLLATE utf8_spanish_ci DEFAULT NULL,
  `fechaInicio` datetime NOT NULL,
  `fechaFinal` datetime NOT NULL,
  `asistencia` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `cumbrelideresmatricula`
--

CREATE TABLE `cumbrelideresmatricula` (
  `codigoCLMatricula` int(11) NOT NULL,
  `codigoCumbreLideres` int(11) NOT NULL,
  `codigoPersona` varchar(15) COLLATE utf8_spanish_ci NOT NULL,
  `saldo` int(11) NOT NULL,
  `abono` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `cumbretimoteos`
--

CREATE TABLE `cumbretimoteos` (
  `codigoCumbreTimoteos` int(11) NOT NULL,
  `nombre` varchar(70) COLLATE utf8_spanish_ci NOT NULL,
  `lema` varchar(50) COLLATE utf8_spanish_ci DEFAULT NULL,
  `objetivo` varchar(400) COLLATE utf8_spanish_ci DEFAULT NULL,
  `fechaInicio` datetime NOT NULL,
  `fechaFinal` datetime NOT NULL,
  `asistencia` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

--
-- Volcado de datos para la tabla `cumbretimoteos`
--

INSERT INTO `cumbretimoteos` (`codigoCumbreTimoteos`, `nombre`, `lema`, `objetivo`, `fechaInicio`, `fechaFinal`, `asistencia`) VALUES
(1, 'Cumbre de las cumbres', 'Cumbrear', 'Que todos cumbreen', '2018-01-11 00:00:00', '2018-01-18 00:12:00', 125),
(2, 'Prueba', 'Probar 12', 'Probar 21', '2018-01-09 14:22:00', '2018-01-13 14:22:00', NULL);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `cumbretimoteosabonos`
--

CREATE TABLE `cumbretimoteosabonos` (
  `codigoCumbreTimoteosAbonos` int(11) NOT NULL,
  `codigoCTMatricula` int(11) NOT NULL,
  `fecha` datetime NOT NULL,
  `abono` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `cumbretimoteosmatricula`
--

CREATE TABLE `cumbretimoteosmatricula` (
  `codigoCTMatricula` int(11) NOT NULL,
  `codigoCumbreTimoteos` int(11) NOT NULL,
  `codigoPersona` varchar(15) COLLATE utf8_spanish_ci NOT NULL,
  `guia` varchar(15) COLLATE utf8_spanish_ci NOT NULL,
  `saldo` int(11) NOT NULL,
  `abono` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `encuentroabonos`
--

CREATE TABLE `encuentroabonos` (
  `codigoEncuentroAbonos` int(11) NOT NULL,
  `codigoEncMatricula` int(11) NOT NULL,
  `fecha` datetime NOT NULL,
  `abono` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `encuentros`
--

CREATE TABLE `encuentros` (
  `codigoEncuentro` int(11) NOT NULL,
  `nombre` varchar(70) COLLATE utf8_spanish_ci NOT NULL,
  `lema` varchar(50) COLLATE utf8_spanish_ci DEFAULT NULL,
  `objetivo` varchar(400) COLLATE utf8_spanish_ci DEFAULT NULL,
  `fechaInicio` datetime NOT NULL,
  `fechaFinal` datetime NOT NULL,
  `asistencia` int(11) DEFAULT NULL,
  `coordinador` varchar(15) COLLATE utf8_spanish_ci DEFAULT NULL,
  `asistente` varchar(15) COLLATE utf8_spanish_ci DEFAULT NULL,
  `logistica` varchar(15) COLLATE utf8_spanish_ci DEFAULT NULL,
  `servidor` varchar(15) COLLATE utf8_spanish_ci DEFAULT NULL,
  `cocina` varchar(15) COLLATE utf8_spanish_ci DEFAULT NULL,
  `asistenteCocina` varchar(15) COLLATE utf8_spanish_ci DEFAULT NULL,
  `musica` varchar(15) COLLATE utf8_spanish_ci DEFAULT NULL,
  `guiaH1` varchar(15) COLLATE utf8_spanish_ci DEFAULT NULL,
  `guiaH2` varchar(15) COLLATE utf8_spanish_ci DEFAULT NULL,
  `guiaM1` varchar(15) COLLATE utf8_spanish_ci DEFAULT NULL,
  `guiaM2` varchar(15) COLLATE utf8_spanish_ci DEFAULT NULL,
  `guia` varchar(15) COLLATE utf8_spanish_ci DEFAULT NULL,
  `finanzas` varchar(15) COLLATE utf8_spanish_ci DEFAULT NULL,
  `decoracion` varchar(15) COLLATE utf8_spanish_ci DEFAULT NULL,
  `totalDinero` int(11) DEFAULT NULL,
  `totalInvertido` int(11) DEFAULT NULL,
  `montoDecoracion` int(11) DEFAULT NULL,
  `montoLogistica` int(11) DEFAULT NULL,
  `montoComida` int(11) DEFAULT NULL,
  `montoServicio` int(11) DEFAULT NULL,
  `montoTransporte` int(11) DEFAULT NULL,
  `totalRestante` int(11) DEFAULT NULL,
  `montoOtros` int(11) DEFAULT NULL,
  `estado` varchar(40) COLLATE utf8_spanish_ci NOT NULL DEFAULT 'Disponible'
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

--
-- Volcado de datos para la tabla `encuentros`
--

INSERT INTO `encuentros` (`codigoEncuentro`, `nombre`, `lema`, `objetivo`, `fechaInicio`, `fechaFinal`, `asistencia`, `coordinador`, `asistente`, `logistica`, `servidor`, `cocina`, `asistenteCocina`, `musica`, `guiaH1`, `guiaH2`, `guiaM1`, `guiaM2`, `guia`, `finanzas`, `decoracion`, `totalDinero`, `totalInvertido`, `montoDecoracion`, `montoLogistica`, `montoComida`, `montoServicio`, `montoTransporte`, `totalRestante`, `montoOtros`, `estado`) VALUES
(1, 'Prueba', 'Esto es una prueba', 'Probar', '2018-01-18 12:11:00', '2018-01-26 01:00:00', NULL, 'ka12345', 'ka12345', 'ka12345', 'ka12345', 'ka12345', 'ka12345', 'CER-123', 'ka12345', 'f10d2a3a-9b96-4', 'c67e0c2b-0558-4', 'AN-100', 'ka12345', 'ka12345', 'ka12345', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'Disponible'),
(2, '', NULL, NULL, '0001-01-01 00:00:00', '0001-01-01 00:00:00', NULL, 'ka12345', 'ka12345', 'ka12345', 'ka12345', 'ka12345', 'ka12345', 'ka12345', 'ka12345', 'ka12345', 'ka12345', 'ka12345', 'ka12345', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'NoDisponible'),
(3, '', NULL, NULL, '0001-01-01 00:00:00', '0001-01-01 00:00:00', NULL, 'ka12345', 'ka12345', 'ka12345', 'ka12345', 'ka12345', 'ka12345', 'ka12345', 'ka12345', 'ka12345', 'ka12345', 'ka12345', 'ka12345', 'ka12345', 'ka12345', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'NoDisponible'),
(4, 'PEPE', 'Pepe pepe pepe', 'Ser como pepe', '2018-01-24 12:11:00', '2018-02-01 16:05:00', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 160, 100, 20, 10, 10, 10, NULL, 10, 'NoDisponible');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `encuentrosmatricula`
--

CREATE TABLE `encuentrosmatricula` (
  `codigoEncMatricula` int(11) NOT NULL,
  `codigoEncuentro` int(11) NOT NULL,
  `codigoPersona` varchar(15) COLLATE utf8_spanish_ci NOT NULL,
  `guia` varchar(15) COLLATE utf8_spanish_ci DEFAULT NULL,
  `saldo` int(11) NOT NULL,
  `abono` int(11) NOT NULL,
  `observaciones` varchar(500) COLLATE utf8_spanish_ci DEFAULT NULL,
  `estado` varchar(40) COLLATE utf8_spanish_ci NOT NULL DEFAULT 'Prematriculado'
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

--
-- Volcado de datos para la tabla `encuentrosmatricula`
--

INSERT INTO `encuentrosmatricula` (`codigoEncMatricula`, `codigoEncuentro`, `codigoPersona`, `guia`, `saldo`, `abono`, `observaciones`, `estado`) VALUES
(2, 1, 'aa1c1e00-3b32-4', 'f10d2a3a-9b96-4', 35000, 0, 'esto es una prueba ak7 123456 pum pum pra pra', 'Prematriculado'),
(3, 1, 'c67e0c2b-0558-4', 'c67e0c2b-0558-4', 35000, 0, 'popopo', 'Prematriculado'),
(4, 1, '72786524-d747-4', 'f10d2a3a-9b96-4', 35000, 0, 'Hola soy una obervacion hola', 'Prematriculado'),
(5, 1, '606ce9d7-96d8-4', 'ka12345', 35000, 0, NULL, 'Prematriculado');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `informescelulares`
--

CREATE TABLE `informescelulares` (
  `codigoInformeCelular` int(11) NOT NULL,
  `codigoCelula` varchar(15) COLLATE utf8_spanish_ci NOT NULL,
  `fecha` datetime NOT NULL,
  `asistencia` int(11) NOT NULL,
  `visitas` int(11) NOT NULL,
  `ofrenda` int(11) NOT NULL,
  `observaciones` varchar(500) COLLATE utf8_spanish_ci DEFAULT NULL,
  `seRealizo` bit(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

--
-- Volcado de datos para la tabla `informescelulares`
--

INSERT INTO `informescelulares` (`codigoInformeCelular`, `codigoCelula`, `fecha`, `asistencia`, `visitas`, `ofrenda`, `observaciones`, `seRealizo`) VALUES
(3, '35fa6479-5ac4-4', '2018-02-08 06:30:00', 17, 3, 5100, '.', b'1');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `matriculaenlinea`
--

CREATE TABLE `matriculaenlinea` (
  `codigoMatriculaEnLinea` varchar(15) COLLATE utf8_spanish_ci NOT NULL,
  `codigoCurso` int(11) NOT NULL,
  `maestro` varchar(15) COLLATE utf8_spanish_ci NOT NULL,
  `fechaInicio` datetime NOT NULL,
  `fechaFinal` datetime NOT NULL,
  `cantEstudiantes` int(11) DEFAULT NULL,
  `cantAprobados` int(11) DEFAULT NULL,
  `cantReprobados` int(11) DEFAULT NULL,
  `montoIngreso` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `matriculaenlineaalumnos`
--

CREATE TABLE `matriculaenlineaalumnos` (
  `codigoMatriculaEnLineaAlumnos` int(11) NOT NULL,
  `alumno` varchar(15) COLLATE utf8_spanish_ci NOT NULL,
  `pago` int(11) DEFAULT NULL,
  `estado` varchar(20) COLLATE utf8_spanish_ci DEFAULT NULL,
  `nota` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ministerios`
--

CREATE TABLE `ministerios` (
  `codigoMinisterio` int(11) NOT NULL,
  `nombre` varchar(40) COLLATE utf8_spanish_ci NOT NULL,
  `descripcion` varchar(500) COLLATE utf8_spanish_ci DEFAULT NULL,
  `cantMiembros` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

--
-- Volcado de datos para la tabla `ministerios`
--

INSERT INTO `ministerios` (`codigoMinisterio`, `nombre`, `descripcion`, `cantMiembros`) VALUES
(1, 'Alcance', 'Gestionar el proceso de multiplicación, restauración y transformación promoviendo el desarrollo de discípulos.', 0),
(2, 'Capacitación', 'Hay que agregar la decripcion u objetivo.', 0),
(3, 'CIA Kids', 'Hay que agregar la decripcion u objetivo.', 0),
(4, 'Anfitriones', 'Hay que agregar la decripcion u objetivo.', 0),
(5, 'Finanzas', 'Hay que agregar la decripcion u objetivo.', 0),
(6, 'Misiones', 'Hay que agregar la decripcion u objetivo.', 0),
(7, 'Social', 'Hay que agregar la decripcion u objetivo.', 0),
(8, 'Comunicación y Tecnología', 'Hay que agregar la decripcion u objetivo.', 0),
(9, 'Intercesión', 'Hay que agregar la decripcion u objetivo.', 0),
(10, 'Alabanza', 'Hay que agregar la decripcion u objetivo.', 0),
(11, 'Sistema', 'Se utiliza para poder usar roles propios del sistema.', 0);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `niveles`
--

CREATE TABLE `niveles` (
  `codigoNivel` int(11) NOT NULL,
  `nombre` varchar(50) COLLATE utf8_spanish_ci NOT NULL,
  `tema` varchar(250) COLLATE utf8_spanish_ci NOT NULL,
  `descripcion` varchar(500) COLLATE utf8_spanish_ci DEFAULT NULL,
  `cantidadLecciones` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

--
-- Volcado de datos para la tabla `niveles`
--

INSERT INTO `niveles` (`codigoNivel`, `nombre`, `tema`, `descripcion`, `cantidadLecciones`) VALUES
(1, 'Post-Encuentro', 'De lo ordinario a lo extraordinario.', '.', 6),
(2, 'Discipulos 1', 'De lo natural a lo sobrenatural.', '.', 6),
(3, 'Discipulos 2', 'Una vida extraordinaria.', '.', 6),
(4, 'Discipulos 3', 'Viviendo de acuerdo a tu propósito.', '.', 6),
(5, 'Discipulos 4', 'Un fundamento solido.', '.', 6),
(6, 'Timoteos 1', 'Una vida sin fronteras.', '.', 6),
(7, 'Timoteos 2', 'Estrategia para cambiar el mundo.', '.', 6),
(8, 'Timoteos 3', 'Desarrollando el liderazgo celular.', '.', 6),
(9, 'Timoteos 4', 'Con las manos en el arado.', '.', 6),
(10, 'Timoteos 5', 'La medida.', '.', 6),
(11, 'Líderes 1', 'Único usted en Cristo.', '.', 1),
(12, 'Líderes 2', 'Línea de tiempo.', '.', 1),
(13, 'Líderes 3', 'Enfoque', '.', 1),
(14, 'Pre-Encuentro', 'Lo mejor esta por venir', '5 Lecciones bases para la persona que esta comenzando', 5);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `niveleslecciones`
--

CREATE TABLE `niveleslecciones` (
  `codigoNivelLeccion` int(11) NOT NULL,
  `codigoNivel` int(11) NOT NULL,
  `nombre` varchar(50) COLLATE utf8_spanish_ci NOT NULL,
  `descripcion` varchar(500) COLLATE utf8_spanish_ci DEFAULT NULL,
  `numeroLeccion` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

--
-- Volcado de datos para la tabla `niveleslecciones`
--

INSERT INTO `niveleslecciones` (`codigoNivelLeccion`, `codigoNivel`, `nombre`, `descripcion`, `numeroLeccion`) VALUES
(1, 1, 'Una vida extraordinaria', '...', 1),
(2, 1, 'Tentado pero no en pecado', '...', 2),
(3, 1, 'Dejando lo ordinario', '...', 3),
(4, 1, 'Gozo vivido no finjido', '...', 4),
(5, 1, 'Más que palabras', '...', 5),
(6, 1, 'Una milla más', '...', 6),
(7, 2, 'Cuando lo natural es lo sobrenatural', '...', 1),
(8, 2, 'Viviendo lo natural de una manera sobrenatural', '...', 2),
(9, 2, 'Viviendo relaciones prodigiosas', '...', 3),
(10, 2, 'Dejando una huella que perdure', '...', 4),
(11, 2, 'El secreto de la transformación', '...', 5),
(12, 2, 'El fruto de una vida sobrenatural', '...', 6),
(13, 3, 'Meditación y Confesión', '...', 1),
(14, 3, 'Oración y Ayuno', '...', 2),
(15, 3, 'El estudio', '...', 3),
(16, 3, 'Mayordomía', '...', 4),
(17, 3, 'Comunión y Servicio', '...', 5),
(18, 3, 'Sumisión', '...', 6),
(19, 4, 'Partiendo del punto de vista correcto', '...', 1),
(20, 4, 'El propósito eterno', '...', 2),
(21, 4, 'Un nuevo marco de referencia', '...', 3),
(22, 4, 'Los ejes de la humanidad', '...', 4),
(23, 4, 'El bien, el mal y la caída', '...', 5),
(24, 4, 'El justo juicio de Dios', '...', 6),
(25, 5, 'El fundamento de las escrituras', '...', 1),
(26, 5, 'El fundamento de la doctrina de Dios', '...', 2),
(27, 5, 'El fundamento doctrinal del pecado', '...', 3),
(28, 5, 'El fundamento doctrinal de la salvación', '...', 4),
(29, 5, 'El fundamento doctrinal de la iglesia', '...', 5),
(30, 5, 'El fundamento doctrinal de la segunda venida de Cr', '...', 6),
(31, 6, 'El timoteo original', '...', 1),
(32, 6, 'Cómo ganar a otros para Cristo: Concepto de evange', '...', 2),
(33, 6, 'Cómo ganar a otros para Cristo: Metodos para evang', '...', 3),
(34, 6, 'Ruta ministerial', '...', 4),
(35, 6, '¿Que es una célula?', '...', 5),
(36, 6, 'Consolidar', '...', 6),
(37, 7, 'Desarrollando el adn de Dios', '...', 1),
(38, 7, 'Realizando el ministerio al estilo de Jesús I', '...', 2),
(39, 7, 'Realizando el ministerio al estilo de Jesús II', '...', 3),
(40, 7, 'Entendiendo los procesos de multiplicación en el r', '...', 4),
(41, 7, 'Señales de una iglesia apostólica', '...', 5),
(42, 7, 'El proceso a la restauración', '...', 6),
(43, 8, 'Siete fundamentos del liderazgo espiritual', '...', 1),
(44, 8, 'Características del líder de equipo', '...', 2),
(45, 8, 'Los miembros del equipo', '...', 3),
(46, 8, 'Quince principios dinamicos para ser un líder de é', '...', 4),
(47, 8, 'Catorce principios dinamicos para tener una célula', '...', 5),
(48, 8, 'Los doce elementos de una interacción ideal en la ', '...', 6),
(49, 9, 'Fe como estilo de vida parte I', '...', 1),
(50, 9, 'Fe como estilo de vida parte II', '...', 2),
(51, 9, '¿Sirviendo por pasión o sirviendo por presión?', '...', 3),
(52, 9, 'El poder de la productividad', '...', 4),
(53, 9, 'La vara y el cayado', '...', 5),
(54, 9, 'Principios espirituales para la resolución de conf', '...', 6),
(55, 10, 'Términos griegos para entendernos mejor', '...', 1),
(56, 10, 'Los lentes para establecer la medida', '...', 2),
(57, 10, 'Surgimiento de los diferentes lente', '...', 3),
(58, 10, 'Las tres justicias', '...', 4),
(59, 10, 'La ley de Cristo', '...', 5),
(60, 10, 'Una visión fragmentada', '...', 6),
(61, 11, 'Cómo combinar los 16 dones espirituales con los 4 ', '...', 1),
(62, 12, 'La soberania de Dios en mi linea de tiempo', '...', 1),
(63, 13, 'Visión, misión y valores personales', '...', 1),
(64, 14, 'Lo mejor esta por venir', '...', 1),
(65, 14, 'Lo mejor esta por venir cuando te sintonizas con s', '...', 2),
(66, 14, 'Lo mejor esta por venir cuando recibes su palabra', '...', 3),
(67, 14, 'Lo mejor esta por venir cuando tu vida le agrada', '...', 4),
(68, 14, 'Lo mejor esta por venir cuando tienes un encuentro', '...', 5);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `personas`
--

CREATE TABLE `personas` (
  `codigoPersona` varchar(15) COLLATE utf8_spanish_ci NOT NULL,
  `codigoMinisterio` int(11) DEFAULT NULL,
  `codigoArea` int(11) DEFAULT NULL,
  `lider` varchar(15) COLLATE utf8_spanish_ci DEFAULT NULL,
  `nombre` varchar(15) COLLATE utf8_spanish_ci NOT NULL,
  `apellido1` varchar(15) COLLATE utf8_spanish_ci NOT NULL,
  `apellido2` varchar(15) COLLATE utf8_spanish_ci NOT NULL,
  `nombreCompletoMadre` varchar(70) COLLATE utf8_spanish_ci DEFAULT NULL,
  `telefonoMadre` varchar(15) COLLATE utf8_spanish_ci DEFAULT NULL,
  `nombreCompletoPadre` varchar(70) COLLATE utf8_spanish_ci DEFAULT NULL,
  `telefonoPadre` varchar(15) COLLATE utf8_spanish_ci DEFAULT NULL,
  `nombreCompletoConyuge` varchar(70) COLLATE utf8_spanish_ci DEFAULT NULL,
  `telefonoConyuge` varchar(15) COLLATE utf8_spanish_ci DEFAULT NULL,
  `nombreCompletoEncargado` varchar(70) COLLATE utf8_spanish_ci DEFAULT NULL,
  `telefonoEncargado` varchar(15) COLLATE utf8_spanish_ci DEFAULT NULL,
  `parentescoEncargado` varchar(20) COLLATE utf8_spanish_ci DEFAULT NULL,
  `telefono` varchar(15) COLLATE utf8_spanish_ci NOT NULL,
  `direccion` varchar(500) COLLATE utf8_spanish_ci DEFAULT NULL,
  `fechaIngreso` datetime DEFAULT NULL,
  `nivelAcademias` int(11) NOT NULL,
  `fechaDeNacimiento` datetime DEFAULT NULL,
  `cumbreTimoteos` bit(1) NOT NULL,
  `cumbreLideres` bit(1) NOT NULL,
  `sexo` varchar(10) COLLATE utf8_spanish_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

--
-- Volcado de datos para la tabla `personas`
--

INSERT INTO `personas` (`codigoPersona`, `codigoMinisterio`, `codigoArea`, `lider`, `nombre`, `apellido1`, `apellido2`, `nombreCompletoMadre`, `telefonoMadre`, `nombreCompletoPadre`, `telefonoPadre`, `nombreCompletoConyuge`, `telefonoConyuge`, `nombreCompletoEncargado`, `telefonoEncargado`, `parentescoEncargado`, `telefono`, `direccion`, `fechaIngreso`, `nivelAcademias`, `fechaDeNacimiento`, `cumbreTimoteos`, `cumbreLideres`, `sexo`) VALUES
('606ce9d7-96d8-4', NULL, NULL, 'ka12345', 'prueba de hola', 'holis', 'holas', 'yuca', '777', 'camote', '8888', NULL, NULL, NULL, NULL, NULL, '45678', '8765gggfrrr', '2018-01-26 00:00:00', 14, '2018-01-27 00:12:00', b'1', b'1', 'Femenino'),
('72786524-d747-4', NULL, NULL, 'ka12345', 'Esteban', 'Marin', 'Chinchilla', NULL, NULL, NULL, NULL, 'Pepa alfonsa marin laguniada', '11111111', 'ronald', '33333333', 'compa de trabajo', '22222222', 'por ahi a la vuelta', '2018-01-26 00:00:00', 14, '2018-01-25 00:12:00', b'1', b'1', 'Masculino'),
('aa1c1e00-3b32-4', NULL, NULL, 'ka12345', 'Pepe', 'ljlkj', 'kljkj', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '43353', 'rrerer', '2018-01-19 00:00:00', 14, '2018-01-26 16:44:00', b'1', b'1', 'ff'),
('AN-100', 11, NULL, 'ka12345', 'Antonia', 'Qwerty', 'Asdpo', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '96325', NULL, NULL, 7, NULL, b'1', b'1', 'Femenino'),
('AND-1234', 7, NULL, 'ka12345', 'Andres', 'Blanco', 'Duran', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '213213', NULL, NULL, 8, NULL, b'1', b'1', 'Masculino'),
('c67e0c2b-0558-4', NULL, NULL, 'ka12345', 'pruebaak7', 'jajaja', 'jajaja', 'jajajaa', '333', 'ajajaja', '333', 'jajaja', '222', 'jj', '222', 'jnjv', '9999', 'jfhjsfbhsbfjhbwfj', '2018-01-19 00:00:00', 14, '2018-01-19 00:12:00', b'1', b'1', 'desconocid'),
('CER-123', 5, NULL, 'ka12345', 'Bryan', 'Cerdas', 'Salas', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '123456', NULL, NULL, 11, '1995-01-18 00:00:00', b'1', b'1', 'Masculino'),
('f10d2a3a-9b96-4', NULL, NULL, 'ka12345', 'Pepe', 'Cerdas', 'Sallon', 'Pepa', '1111', 'Pepo', '2222', 'Pepina', '3333', 'Pepino', '4444', 'vegetal', '5555', 'verdureria', '2018-01-19 00:00:00', 14, '2018-01-19 00:12:00', b'1', b'1', 'tuberculo'),
('ka12345', 8, NULL, 'ka12345', 'Kamil', 'Sallon', 'Arroyo', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '131132', NULL, NULL, 3, '1997-01-02 00:00:00', b'1', b'1', 'Masculino'),
('ME-44444', 3, NULL, 'ka12345', 'Maria', 'CAA', 'PEEE', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, '12222', NULL, NULL, 6, '2018-01-03 00:00:00', b'1', b'1', 'Femenino');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `personasroles`
--

CREATE TABLE `personasroles` (
  `codigoPersonasRoles` int(11) NOT NULL,
  `codigoPersona` varchar(15) COLLATE utf8_spanish_ci NOT NULL,
  `codigoRol` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

--
-- Volcado de datos para la tabla `personasroles`
--

INSERT INTO `personasroles` (`codigoPersonasRoles`, `codigoPersona`, `codigoRol`) VALUES
(1, 'CER-123', 2),
(2, 'ka12345', 2),
(3, 'AN-100', 2),
(4, 'ME-44444', 5),
(5, 'f10d2a3a-9b96-4', 2),
(6, 'CER-123', 11),
(7, 'c67e0c2b-0558-4', 2),
(8, 'CER-123', 8),
(9, 'AN-100', 8),
(10, 'f10d2a3a-9b96-4', 8),
(11, 'ME-44444', 8);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `procesoox3`
--

CREATE TABLE `procesoox3` (
  `codigoProcesoOx3` int(11) NOT NULL,
  `fechaInicio` datetime NOT NULL,
  `fechaFinal` datetime NOT NULL,
  `cantOrando` int(11) NOT NULL,
  `totalConvertidos` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `procesoox3informer5`
--

CREATE TABLE `procesoox3informer5` (
  `codigoProcesoOx3InformeR5` int(11) NOT NULL,
  `codigoProcesoOx3Personas` int(11) NOT NULL,
  `asistencia` int(11) NOT NULL,
  `convertidos` int(11) NOT NULL,
  `visitas` int(11) NOT NULL,
  `ofrenda` int(11) NOT NULL,
  `observaciones` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `procesoox3informer6`
--

CREATE TABLE `procesoox3informer6` (
  `codigoProcesoOx3InformeR6` int(11) NOT NULL,
  `codigoProcesoOx3Personas` int(11) NOT NULL,
  `asistencia` int(11) NOT NULL,
  `convertidos` int(11) NOT NULL,
  `visitas` int(11) NOT NULL,
  `ofrenda` int(11) NOT NULL,
  `observaciones` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `procesoox3personas`
--

CREATE TABLE `procesoox3personas` (
  `codigoProcesoOx3Personas` int(11) NOT NULL,
  `codigoProcesoOx3` int(11) NOT NULL,
  `codigopersona` varchar(15) COLLATE utf8_spanish_ci DEFAULT NULL,
  `nombre1` varchar(70) COLLATE utf8_spanish_ci NOT NULL,
  `nombre2` varchar(70) COLLATE utf8_spanish_ci NOT NULL,
  `nombre3` varchar(70) COLLATE utf8_spanish_ci NOT NULL,
  `observaciones1` varchar(500) COLLATE utf8_spanish_ci DEFAULT NULL,
  `observaciones2` varchar(500) COLLATE utf8_spanish_ci DEFAULT NULL,
  `observaciones3` varchar(500) COLLATE utf8_spanish_ci DEFAULT NULL,
  `contactoUno1` bit(1) DEFAULT NULL,
  `contactoUno2` bit(1) DEFAULT NULL,
  `contactoUno3` bit(1) DEFAULT NULL,
  `contactoDos1` bit(1) DEFAULT NULL,
  `contactoDos2` bit(1) DEFAULT NULL,
  `contactoDos3` bit(1) DEFAULT NULL,
  `r5Fecha` datetime DEFAULT NULL,
  `r5Lugar` varchar(40) COLLATE utf8_spanish_ci DEFAULT NULL,
  `r5Direccion` varchar(500) COLLATE utf8_spanish_ci DEFAULT NULL,
  `r5Hora` varchar(10) COLLATE utf8_spanish_ci DEFAULT NULL,
  `r6Fecha` datetime DEFAULT NULL,
  `r6Lugar` varchar(40) COLLATE utf8_spanish_ci DEFAULT NULL,
  `r6Direccion` varchar(500) COLLATE utf8_spanish_ci DEFAULT NULL,
  `r6Hora` varchar(10) COLLATE utf8_spanish_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `reencuentroabonos`
--

CREATE TABLE `reencuentroabonos` (
  `codigoReecuentroAbonos` int(11) NOT NULL,
  `codigoReMatricula` int(11) NOT NULL,
  `fecha` datetime NOT NULL,
  `abono` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `reencuentros`
--

CREATE TABLE `reencuentros` (
  `codigoReencuentro` int(11) NOT NULL,
  `nombre` varchar(70) COLLATE utf8_spanish_ci NOT NULL,
  `lema` varchar(50) COLLATE utf8_spanish_ci DEFAULT NULL,
  `objetivo` varchar(400) COLLATE utf8_spanish_ci DEFAULT NULL,
  `fechaInicio` datetime NOT NULL,
  `fechaFinal` datetime NOT NULL,
  `asistencia` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `reencuentrosmatricula`
--

CREATE TABLE `reencuentrosmatricula` (
  `codigoReMatricula` int(11) NOT NULL,
  `codigoReencuentro` int(11) NOT NULL,
  `codigoPersona` varchar(15) COLLATE utf8_spanish_ci NOT NULL,
  `guia` varchar(15) COLLATE utf8_spanish_ci NOT NULL,
  `saldo` int(11) NOT NULL,
  `abono` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `roles`
--

CREATE TABLE `roles` (
  `codigoRol` int(11) NOT NULL,
  `codigoMinisterio` int(11) NOT NULL,
  `nombre` varchar(40) COLLATE utf8_spanish_ci NOT NULL,
  `descripcion` varchar(500) COLLATE utf8_spanish_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

--
-- Volcado de datos para la tabla `roles`
--

INSERT INTO `roles` (`codigoRol`, `codigoMinisterio`, `nombre`, `descripcion`) VALUES
(1, 11, 'Administración', 'Tiene acceso a todo el sistema con funciones de mantenimiento.'),
(2, 1, 'Lider de célula', 'Persona a cargo de una célula en la iglesia.'),
(3, 1, 'Coordinador', 'Encargado del ministerio de Alcance.'),
(4, 1, 'Ox3', 'Encargado del área de oración por tres.'),
(5, 1, 'Consolidación', 'Encargado del área de Consolidación.'),
(6, 1, 'Supervisión celular', 'Encargado del área de Supervisión celular.'),
(7, 2, 'Coordinador', 'Encargado del ministeria de Capacitación.'),
(8, 2, 'Maestro de academias', 'Persona que imparte las lecciones en las academias.'),
(9, 2, 'Maestro virtual', 'Persona que está a cargo de cursos en las academias virtuales.'),
(10, 2, 'Encargado', '...'),
(11, 10, 'Musico', '...');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `usuarios`
--

CREATE TABLE `usuarios` (
  `usuario` varchar(25) COLLATE utf8_spanish_ci NOT NULL,
  `codigoPersona` varchar(15) COLLATE utf8_spanish_ci NOT NULL,
  `correo` varchar(50) COLLATE utf8_spanish_ci NOT NULL,
  `clave` varchar(500) COLLATE utf8_spanish_ci NOT NULL,
  `codigoRecuperacion` varchar(20) COLLATE utf8_spanish_ci DEFAULT NULL,
  `correoSeguridad` varchar(50) COLLATE utf8_spanish_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_spanish_ci;

--
-- Volcado de datos para la tabla `usuarios`
--

INSERT INTO `usuarios` (`usuario`, `codigoPersona`, `correo`, `clave`, `codigoRecuperacion`, `correoSeguridad`) VALUES
('ksallon', 'ka12345', 'ksallon@gmail.com', 'tvZ8FHaQRAw=', NULL, NULL),
('pepe', 'ME-44444', 'me@gmail.com', 'tvZ8FHaQRAw=', NULL, NULL);

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `academias`
--
ALTER TABLE `academias`
  ADD PRIMARY KEY (`codigoAcademias`);

--
-- Indices de la tabla `academiasabono`
--
ALTER TABLE `academiasabono`
  ADD PRIMARY KEY (`codigoAcademiaAbono`),
  ADD KEY `codigoAcademiasMatricula` (`codigoAcademiasMatricula`);

--
-- Indices de la tabla `academiaslecciones`
--
ALTER TABLE `academiaslecciones`
  ADD PRIMARY KEY (`codigoAcademiaLeccion`),
  ADD KEY `codigoAcademias` (`codigoAcademias`),
  ADD KEY `codigoMaestro` (`codigoMaestro`),
  ADD KEY `codigoLeccion` (`codigoLeccion`),
  ADD KEY `codigoAcademiaNivel` (`codigoAcademiaNivel`);

--
-- Indices de la tabla `academiasmatriculas`
--
ALTER TABLE `academiasmatriculas`
  ADD PRIMARY KEY (`codigoAcademiaMatricula`),
  ADD KEY `codigoAcademias` (`codigoAcademias`),
  ADD KEY `codigoPersona` (`codigoPersona`),
  ADD KEY `codigoNivel` (`codigoNivel`),
  ADD KEY `codigoAcademiaNivel` (`codigoAcademiaNivel`);

--
-- Indices de la tabla `academiasniveles`
--
ALTER TABLE `academiasniveles`
  ADD PRIMARY KEY (`codigoAcademiasNiveles`),
  ADD KEY `codigoAcademias` (`codigoAcademias`),
  ADD KEY `codigoNivel` (`codigoNivel`);

--
-- Indices de la tabla `areasdeministerio`
--
ALTER TABLE `areasdeministerio`
  ADD PRIMARY KEY (`codigoArea`),
  ADD KEY `codigoMinisterio` (`codigoMinisterio`);

--
-- Indices de la tabla `boletasconsolidacion`
--
ALTER TABLE `boletasconsolidacion`
  ADD PRIMARY KEY (`codigoBoleta`),
  ADD KEY `personaAsignada` (`personaAsignada`),
  ADD KEY `celulaDe` (`celulaDe`),
  ADD KEY `llenadoPor` (`llenadoPor`);

--
-- Indices de la tabla `celulas`
--
ALTER TABLE `celulas`
  ADD PRIMARY KEY (`codigoCelula`),
  ADD KEY `lider` (`lider`),
  ADD KEY `asistente` (`asistente`),
  ADD KEY `celulaRaiz` (`celulaRaiz`);

--
-- Indices de la tabla `celulaspersonas`
--
ALTER TABLE `celulaspersonas`
  ADD PRIMARY KEY (`codigoCelulasPersonas`),
  ADD KEY `codigoPersona` (`codigoPersona`),
  ADD KEY `codigoCelula` (`codigoCelula`);

--
-- Indices de la tabla `chatmensajes`
--
ALTER TABLE `chatmensajes`
  ADD PRIMARY KEY (`codigoChatMensajes`),
  ADD KEY `persona1` (`persona1`),
  ADD KEY `persona2` (`persona2`);

--
-- Indices de la tabla `cumbrelideres`
--
ALTER TABLE `cumbrelideres`
  ADD PRIMARY KEY (`codigoCumbreLideres`);

--
-- Indices de la tabla `cumbrelideresmatricula`
--
ALTER TABLE `cumbrelideresmatricula`
  ADD PRIMARY KEY (`codigoCLMatricula`),
  ADD KEY `codigoCumbreLideres` (`codigoCumbreLideres`),
  ADD KEY `codigoPersona` (`codigoPersona`);

--
-- Indices de la tabla `cumbretimoteos`
--
ALTER TABLE `cumbretimoteos`
  ADD PRIMARY KEY (`codigoCumbreTimoteos`);

--
-- Indices de la tabla `cumbretimoteosabonos`
--
ALTER TABLE `cumbretimoteosabonos`
  ADD PRIMARY KEY (`codigoCumbreTimoteosAbonos`),
  ADD KEY `codigoCTMatricula` (`codigoCTMatricula`);

--
-- Indices de la tabla `cumbretimoteosmatricula`
--
ALTER TABLE `cumbretimoteosmatricula`
  ADD PRIMARY KEY (`codigoCTMatricula`),
  ADD KEY `codigoCumbreTimoteos` (`codigoCumbreTimoteos`),
  ADD KEY `codigoPersona` (`codigoPersona`),
  ADD KEY `guia` (`guia`);

--
-- Indices de la tabla `encuentroabonos`
--
ALTER TABLE `encuentroabonos`
  ADD PRIMARY KEY (`codigoEncuentroAbonos`),
  ADD KEY `codigoEncMatricula` (`codigoEncMatricula`);

--
-- Indices de la tabla `encuentros`
--
ALTER TABLE `encuentros`
  ADD PRIMARY KEY (`codigoEncuentro`),
  ADD KEY `coordinador` (`coordinador`),
  ADD KEY `asistente` (`asistente`),
  ADD KEY `logistica` (`logistica`),
  ADD KEY `servidor` (`servidor`),
  ADD KEY `cocina` (`cocina`),
  ADD KEY `asistenteCocina` (`asistenteCocina`),
  ADD KEY `musica` (`musica`),
  ADD KEY `guiaH1` (`guiaH1`),
  ADD KEY `guiaH2` (`guiaH2`),
  ADD KEY `guiaM1` (`guiaM1`),
  ADD KEY `guiaM2` (`guiaM2`),
  ADD KEY `guia` (`guia`),
  ADD KEY `finanzas` (`finanzas`),
  ADD KEY `decoracion` (`decoracion`);

--
-- Indices de la tabla `encuentrosmatricula`
--
ALTER TABLE `encuentrosmatricula`
  ADD PRIMARY KEY (`codigoEncMatricula`),
  ADD KEY `codigoEncuentro` (`codigoEncuentro`),
  ADD KEY `codigoPersona` (`codigoPersona`),
  ADD KEY `guia` (`guia`);

--
-- Indices de la tabla `informescelulares`
--
ALTER TABLE `informescelulares`
  ADD PRIMARY KEY (`codigoInformeCelular`),
  ADD KEY `codigoCelula` (`codigoCelula`);

--
-- Indices de la tabla `matriculaenlinea`
--
ALTER TABLE `matriculaenlinea`
  ADD PRIMARY KEY (`codigoMatriculaEnLinea`),
  ADD KEY `codigoCurso` (`codigoCurso`),
  ADD KEY `maestro` (`maestro`);

--
-- Indices de la tabla `matriculaenlineaalumnos`
--
ALTER TABLE `matriculaenlineaalumnos`
  ADD PRIMARY KEY (`codigoMatriculaEnLineaAlumnos`),
  ADD KEY `alumno` (`alumno`);

--
-- Indices de la tabla `ministerios`
--
ALTER TABLE `ministerios`
  ADD PRIMARY KEY (`codigoMinisterio`);

--
-- Indices de la tabla `niveles`
--
ALTER TABLE `niveles`
  ADD PRIMARY KEY (`codigoNivel`);

--
-- Indices de la tabla `niveleslecciones`
--
ALTER TABLE `niveleslecciones`
  ADD PRIMARY KEY (`codigoNivelLeccion`),
  ADD KEY `codigoNivel` (`codigoNivel`);

--
-- Indices de la tabla `personas`
--
ALTER TABLE `personas`
  ADD PRIMARY KEY (`codigoPersona`),
  ADD KEY `codigoMinisterio` (`codigoMinisterio`),
  ADD KEY `codigoArea` (`codigoArea`),
  ADD KEY `nivelAcademias` (`nivelAcademias`),
  ADD KEY `lider` (`lider`);

--
-- Indices de la tabla `personasroles`
--
ALTER TABLE `personasroles`
  ADD PRIMARY KEY (`codigoPersonasRoles`),
  ADD KEY `codigoPersona` (`codigoPersona`),
  ADD KEY `codigoRol` (`codigoRol`);

--
-- Indices de la tabla `procesoox3`
--
ALTER TABLE `procesoox3`
  ADD PRIMARY KEY (`codigoProcesoOx3`);

--
-- Indices de la tabla `procesoox3informer5`
--
ALTER TABLE `procesoox3informer5`
  ADD PRIMARY KEY (`codigoProcesoOx3InformeR5`),
  ADD KEY `codigoProcesoOx3Personas` (`codigoProcesoOx3Personas`);

--
-- Indices de la tabla `procesoox3informer6`
--
ALTER TABLE `procesoox3informer6`
  ADD PRIMARY KEY (`codigoProcesoOx3InformeR6`),
  ADD KEY `codigoProcesoOx3Personas` (`codigoProcesoOx3Personas`);

--
-- Indices de la tabla `procesoox3personas`
--
ALTER TABLE `procesoox3personas`
  ADD PRIMARY KEY (`codigoProcesoOx3Personas`),
  ADD KEY `codigoProcesoOx3` (`codigoProcesoOx3`),
  ADD KEY `codigopersona` (`codigopersona`);

--
-- Indices de la tabla `reencuentroabonos`
--
ALTER TABLE `reencuentroabonos`
  ADD PRIMARY KEY (`codigoReecuentroAbonos`),
  ADD KEY `codigoReMatricula` (`codigoReMatricula`);

--
-- Indices de la tabla `reencuentros`
--
ALTER TABLE `reencuentros`
  ADD PRIMARY KEY (`codigoReencuentro`);

--
-- Indices de la tabla `reencuentrosmatricula`
--
ALTER TABLE `reencuentrosmatricula`
  ADD PRIMARY KEY (`codigoReMatricula`),
  ADD KEY `codigoReencuentro` (`codigoReencuentro`),
  ADD KEY `codigoPersona` (`codigoPersona`),
  ADD KEY `guia` (`guia`);

--
-- Indices de la tabla `roles`
--
ALTER TABLE `roles`
  ADD PRIMARY KEY (`codigoRol`),
  ADD KEY `codigoMinisterio` (`codigoMinisterio`);

--
-- Indices de la tabla `usuarios`
--
ALTER TABLE `usuarios`
  ADD PRIMARY KEY (`usuario`),
  ADD KEY `codigoPersona` (`codigoPersona`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `academias`
--
ALTER TABLE `academias`
  MODIFY `codigoAcademias` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;
--
-- AUTO_INCREMENT de la tabla `academiasabono`
--
ALTER TABLE `academiasabono`
  MODIFY `codigoAcademiaAbono` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=22;
--
-- AUTO_INCREMENT de la tabla `academiaslecciones`
--
ALTER TABLE `academiaslecciones`
  MODIFY `codigoAcademiaLeccion` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=52;
--
-- AUTO_INCREMENT de la tabla `academiasmatriculas`
--
ALTER TABLE `academiasmatriculas`
  MODIFY `codigoAcademiaMatricula` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=22;
--
-- AUTO_INCREMENT de la tabla `academiasniveles`
--
ALTER TABLE `academiasniveles`
  MODIFY `codigoAcademiasNiveles` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=27;
--
-- AUTO_INCREMENT de la tabla `areasdeministerio`
--
ALTER TABLE `areasdeministerio`
  MODIFY `codigoArea` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT de la tabla `boletasconsolidacion`
--
ALTER TABLE `boletasconsolidacion`
  MODIFY `codigoBoleta` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT de la tabla `celulaspersonas`
--
ALTER TABLE `celulaspersonas`
  MODIFY `codigoCelulasPersonas` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT de la tabla `chatmensajes`
--
ALTER TABLE `chatmensajes`
  MODIFY `codigoChatMensajes` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT de la tabla `cumbrelideres`
--
ALTER TABLE `cumbrelideres`
  MODIFY `codigoCumbreLideres` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT de la tabla `cumbrelideresmatricula`
--
ALTER TABLE `cumbrelideresmatricula`
  MODIFY `codigoCLMatricula` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT de la tabla `cumbretimoteos`
--
ALTER TABLE `cumbretimoteos`
  MODIFY `codigoCumbreTimoteos` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;
--
-- AUTO_INCREMENT de la tabla `cumbretimoteosabonos`
--
ALTER TABLE `cumbretimoteosabonos`
  MODIFY `codigoCumbreTimoteosAbonos` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT de la tabla `cumbretimoteosmatricula`
--
ALTER TABLE `cumbretimoteosmatricula`
  MODIFY `codigoCTMatricula` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT de la tabla `encuentroabonos`
--
ALTER TABLE `encuentroabonos`
  MODIFY `codigoEncuentroAbonos` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT de la tabla `encuentros`
--
ALTER TABLE `encuentros`
  MODIFY `codigoEncuentro` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;
--
-- AUTO_INCREMENT de la tabla `encuentrosmatricula`
--
ALTER TABLE `encuentrosmatricula`
  MODIFY `codigoEncMatricula` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;
--
-- AUTO_INCREMENT de la tabla `informescelulares`
--
ALTER TABLE `informescelulares`
  MODIFY `codigoInformeCelular` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;
--
-- AUTO_INCREMENT de la tabla `matriculaenlineaalumnos`
--
ALTER TABLE `matriculaenlineaalumnos`
  MODIFY `codigoMatriculaEnLineaAlumnos` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT de la tabla `ministerios`
--
ALTER TABLE `ministerios`
  MODIFY `codigoMinisterio` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;
--
-- AUTO_INCREMENT de la tabla `niveles`
--
ALTER TABLE `niveles`
  MODIFY `codigoNivel` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;
--
-- AUTO_INCREMENT de la tabla `niveleslecciones`
--
ALTER TABLE `niveleslecciones`
  MODIFY `codigoNivelLeccion` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=69;
--
-- AUTO_INCREMENT de la tabla `personasroles`
--
ALTER TABLE `personasroles`
  MODIFY `codigoPersonasRoles` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;
--
-- AUTO_INCREMENT de la tabla `procesoox3`
--
ALTER TABLE `procesoox3`
  MODIFY `codigoProcesoOx3` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT de la tabla `procesoox3informer5`
--
ALTER TABLE `procesoox3informer5`
  MODIFY `codigoProcesoOx3InformeR5` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT de la tabla `procesoox3informer6`
--
ALTER TABLE `procesoox3informer6`
  MODIFY `codigoProcesoOx3InformeR6` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT de la tabla `procesoox3personas`
--
ALTER TABLE `procesoox3personas`
  MODIFY `codigoProcesoOx3Personas` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT de la tabla `reencuentroabonos`
--
ALTER TABLE `reencuentroabonos`
  MODIFY `codigoReecuentroAbonos` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT de la tabla `reencuentros`
--
ALTER TABLE `reencuentros`
  MODIFY `codigoReencuentro` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT de la tabla `reencuentrosmatricula`
--
ALTER TABLE `reencuentrosmatricula`
  MODIFY `codigoReMatricula` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT de la tabla `roles`
--
ALTER TABLE `roles`
  MODIFY `codigoRol` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;
--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `academiasabono`
--
ALTER TABLE `academiasabono`
  ADD CONSTRAINT `academiasabono_ibfk_1` FOREIGN KEY (`codigoAcademiasMatricula`) REFERENCES `academiasmatriculas` (`codigoAcademiaMatricula`);

--
-- Filtros para la tabla `academiaslecciones`
--
ALTER TABLE `academiaslecciones`
  ADD CONSTRAINT `academiaslecciones_ibfk_1` FOREIGN KEY (`codigoAcademias`) REFERENCES `academias` (`codigoAcademias`),
  ADD CONSTRAINT `academiaslecciones_ibfk_2` FOREIGN KEY (`codigoMaestro`) REFERENCES `personas` (`codigoPersona`),
  ADD CONSTRAINT `academiaslecciones_ibfk_3` FOREIGN KEY (`codigoLeccion`) REFERENCES `niveleslecciones` (`codigoNivelLeccion`),
  ADD CONSTRAINT `academiaslecciones_ibfk_4` FOREIGN KEY (`codigoAcademiaNivel`) REFERENCES `academiasniveles` (`codigoAcademiasNiveles`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Filtros para la tabla `academiasmatriculas`
--
ALTER TABLE `academiasmatriculas`
  ADD CONSTRAINT `academiasmatriculas_ibfk_1` FOREIGN KEY (`codigoAcademias`) REFERENCES `academias` (`codigoAcademias`),
  ADD CONSTRAINT `academiasmatriculas_ibfk_2` FOREIGN KEY (`codigoPersona`) REFERENCES `personas` (`codigoPersona`),
  ADD CONSTRAINT `academiasmatriculas_ibfk_3` FOREIGN KEY (`codigoNivel`) REFERENCES `niveles` (`codigoNivel`),
  ADD CONSTRAINT `academiasmatriculas_ibfk_4` FOREIGN KEY (`codigoAcademiaNivel`) REFERENCES `academiasniveles` (`codigoAcademiasNiveles`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Filtros para la tabla `academiasniveles`
--
ALTER TABLE `academiasniveles`
  ADD CONSTRAINT `academiasniveles_ibfk_1` FOREIGN KEY (`codigoAcademias`) REFERENCES `academias` (`codigoAcademias`),
  ADD CONSTRAINT `academiasniveles_ibfk_2` FOREIGN KEY (`codigoNivel`) REFERENCES `niveles` (`codigoNivel`);

--
-- Filtros para la tabla `areasdeministerio`
--
ALTER TABLE `areasdeministerio`
  ADD CONSTRAINT `areasdeministerio_ibfk_1` FOREIGN KEY (`codigoMinisterio`) REFERENCES `ministerios` (`codigoMinisterio`);

--
-- Filtros para la tabla `boletasconsolidacion`
--
ALTER TABLE `boletasconsolidacion`
  ADD CONSTRAINT `boletasconsolidacion_ibfk_1` FOREIGN KEY (`personaAsignada`) REFERENCES `personas` (`codigoPersona`),
  ADD CONSTRAINT `boletasconsolidacion_ibfk_2` FOREIGN KEY (`celulaDe`) REFERENCES `celulas` (`codigoCelula`),
  ADD CONSTRAINT `boletasconsolidacion_ibfk_3` FOREIGN KEY (`llenadoPor`) REFERENCES `personas` (`codigoPersona`);

--
-- Filtros para la tabla `celulas`
--
ALTER TABLE `celulas`
  ADD CONSTRAINT `celulas_ibfk_1` FOREIGN KEY (`lider`) REFERENCES `personas` (`codigoPersona`),
  ADD CONSTRAINT `celulas_ibfk_2` FOREIGN KEY (`asistente`) REFERENCES `personas` (`codigoPersona`),
  ADD CONSTRAINT `celulas_ibfk_3` FOREIGN KEY (`celulaRaiz`) REFERENCES `celulas` (`codigoCelula`);

--
-- Filtros para la tabla `celulaspersonas`
--
ALTER TABLE `celulaspersonas`
  ADD CONSTRAINT `celulaspersonas_ibfk_1` FOREIGN KEY (`codigoPersona`) REFERENCES `personas` (`codigoPersona`),
  ADD CONSTRAINT `celulaspersonas_ibfk_2` FOREIGN KEY (`codigoCelula`) REFERENCES `celulas` (`codigoCelula`);

--
-- Filtros para la tabla `chatmensajes`
--
ALTER TABLE `chatmensajes`
  ADD CONSTRAINT `chatmensajes_ibfk_1` FOREIGN KEY (`persona1`) REFERENCES `personas` (`codigoPersona`),
  ADD CONSTRAINT `chatmensajes_ibfk_2` FOREIGN KEY (`persona2`) REFERENCES `personas` (`codigoPersona`);

--
-- Filtros para la tabla `cumbrelideresmatricula`
--
ALTER TABLE `cumbrelideresmatricula`
  ADD CONSTRAINT `cumbrelideresmatricula_ibfk_1` FOREIGN KEY (`codigoCumbreLideres`) REFERENCES `cumbrelideres` (`codigoCumbreLideres`),
  ADD CONSTRAINT `cumbrelideresmatricula_ibfk_2` FOREIGN KEY (`codigoPersona`) REFERENCES `personas` (`codigoPersona`);

--
-- Filtros para la tabla `cumbretimoteosabonos`
--
ALTER TABLE `cumbretimoteosabonos`
  ADD CONSTRAINT `cumbretimoteosabonos_ibfk_1` FOREIGN KEY (`codigoCTMatricula`) REFERENCES `cumbretimoteosmatricula` (`codigoCTMatricula`);

--
-- Filtros para la tabla `cumbretimoteosmatricula`
--
ALTER TABLE `cumbretimoteosmatricula`
  ADD CONSTRAINT `cumbretimoteosmatricula_ibfk_1` FOREIGN KEY (`codigoCumbreTimoteos`) REFERENCES `cumbretimoteos` (`codigoCumbreTimoteos`),
  ADD CONSTRAINT `cumbretimoteosmatricula_ibfk_2` FOREIGN KEY (`codigoPersona`) REFERENCES `personas` (`codigoPersona`),
  ADD CONSTRAINT `cumbretimoteosmatricula_ibfk_3` FOREIGN KEY (`guia`) REFERENCES `personas` (`codigoPersona`);

--
-- Filtros para la tabla `encuentroabonos`
--
ALTER TABLE `encuentroabonos`
  ADD CONSTRAINT `encuentroabonos_ibfk_1` FOREIGN KEY (`codigoEncMatricula`) REFERENCES `encuentrosmatricula` (`codigoEncMatricula`);

--
-- Filtros para la tabla `encuentros`
--
ALTER TABLE `encuentros`
  ADD CONSTRAINT `encuentros_ibfk_1` FOREIGN KEY (`coordinador`) REFERENCES `personas` (`codigoPersona`),
  ADD CONSTRAINT `encuentros_ibfk_10` FOREIGN KEY (`guiaM1`) REFERENCES `personas` (`codigoPersona`),
  ADD CONSTRAINT `encuentros_ibfk_11` FOREIGN KEY (`guiaM2`) REFERENCES `personas` (`codigoPersona`),
  ADD CONSTRAINT `encuentros_ibfk_12` FOREIGN KEY (`guia`) REFERENCES `personas` (`codigoPersona`),
  ADD CONSTRAINT `encuentros_ibfk_13` FOREIGN KEY (`finanzas`) REFERENCES `personas` (`codigoPersona`),
  ADD CONSTRAINT `encuentros_ibfk_14` FOREIGN KEY (`decoracion`) REFERENCES `personas` (`codigoPersona`),
  ADD CONSTRAINT `encuentros_ibfk_2` FOREIGN KEY (`asistente`) REFERENCES `personas` (`codigoPersona`),
  ADD CONSTRAINT `encuentros_ibfk_3` FOREIGN KEY (`logistica`) REFERENCES `personas` (`codigoPersona`),
  ADD CONSTRAINT `encuentros_ibfk_4` FOREIGN KEY (`servidor`) REFERENCES `personas` (`codigoPersona`),
  ADD CONSTRAINT `encuentros_ibfk_5` FOREIGN KEY (`cocina`) REFERENCES `personas` (`codigoPersona`),
  ADD CONSTRAINT `encuentros_ibfk_6` FOREIGN KEY (`asistenteCocina`) REFERENCES `personas` (`codigoPersona`),
  ADD CONSTRAINT `encuentros_ibfk_7` FOREIGN KEY (`musica`) REFERENCES `personas` (`codigoPersona`),
  ADD CONSTRAINT `encuentros_ibfk_8` FOREIGN KEY (`guiaH1`) REFERENCES `personas` (`codigoPersona`),
  ADD CONSTRAINT `encuentros_ibfk_9` FOREIGN KEY (`guiaH2`) REFERENCES `personas` (`codigoPersona`);

--
-- Filtros para la tabla `encuentrosmatricula`
--
ALTER TABLE `encuentrosmatricula`
  ADD CONSTRAINT `encuentrosmatricula_ibfk_1` FOREIGN KEY (`codigoEncuentro`) REFERENCES `encuentros` (`codigoEncuentro`),
  ADD CONSTRAINT `encuentrosmatricula_ibfk_2` FOREIGN KEY (`codigoPersona`) REFERENCES `personas` (`codigoPersona`),
  ADD CONSTRAINT `encuentrosmatricula_ibfk_3` FOREIGN KEY (`guia`) REFERENCES `personas` (`codigoPersona`);

--
-- Filtros para la tabla `informescelulares`
--
ALTER TABLE `informescelulares`
  ADD CONSTRAINT `informescelulares_ibfk_1` FOREIGN KEY (`codigoCelula`) REFERENCES `celulas` (`codigoCelula`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Filtros para la tabla `matriculaenlinea`
--
ALTER TABLE `matriculaenlinea`
  ADD CONSTRAINT `matriculaenlinea_ibfk_1` FOREIGN KEY (`codigoCurso`) REFERENCES `niveles` (`codigoNivel`),
  ADD CONSTRAINT `matriculaenlinea_ibfk_2` FOREIGN KEY (`maestro`) REFERENCES `personas` (`codigoPersona`);

--
-- Filtros para la tabla `matriculaenlineaalumnos`
--
ALTER TABLE `matriculaenlineaalumnos`
  ADD CONSTRAINT `matriculaenlineaalumnos_ibfk_1` FOREIGN KEY (`alumno`) REFERENCES `personas` (`codigoPersona`);

--
-- Filtros para la tabla `niveleslecciones`
--
ALTER TABLE `niveleslecciones`
  ADD CONSTRAINT `niveleslecciones_ibfk_1` FOREIGN KEY (`codigoNivel`) REFERENCES `niveles` (`codigoNivel`);

--
-- Filtros para la tabla `personas`
--
ALTER TABLE `personas`
  ADD CONSTRAINT `personas_ibfk_1` FOREIGN KEY (`codigoMinisterio`) REFERENCES `ministerios` (`codigoMinisterio`),
  ADD CONSTRAINT `personas_ibfk_2` FOREIGN KEY (`codigoArea`) REFERENCES `areasdeministerio` (`codigoArea`),
  ADD CONSTRAINT `personas_ibfk_3` FOREIGN KEY (`nivelAcademias`) REFERENCES `niveles` (`codigoNivel`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `personas_ibfk_4` FOREIGN KEY (`lider`) REFERENCES `personas` (`codigoPersona`);

--
-- Filtros para la tabla `personasroles`
--
ALTER TABLE `personasroles`
  ADD CONSTRAINT `personasroles_ibfk_1` FOREIGN KEY (`codigoPersona`) REFERENCES `personas` (`codigoPersona`),
  ADD CONSTRAINT `personasroles_ibfk_2` FOREIGN KEY (`codigoRol`) REFERENCES `roles` (`codigoRol`);

--
-- Filtros para la tabla `procesoox3informer5`
--
ALTER TABLE `procesoox3informer5`
  ADD CONSTRAINT `procesoox3informer5_ibfk_1` FOREIGN KEY (`codigoProcesoOx3Personas`) REFERENCES `procesoox3personas` (`codigoProcesoOx3Personas`);

--
-- Filtros para la tabla `procesoox3informer6`
--
ALTER TABLE `procesoox3informer6`
  ADD CONSTRAINT `procesoox3informer6_ibfk_1` FOREIGN KEY (`codigoProcesoOx3Personas`) REFERENCES `procesoox3personas` (`codigoProcesoOx3Personas`);

--
-- Filtros para la tabla `procesoox3personas`
--
ALTER TABLE `procesoox3personas`
  ADD CONSTRAINT `procesoox3personas_ibfk_1` FOREIGN KEY (`codigoProcesoOx3`) REFERENCES `procesoox3` (`codigoProcesoOx3`),
  ADD CONSTRAINT `procesoox3personas_ibfk_2` FOREIGN KEY (`codigopersona`) REFERENCES `personas` (`codigoPersona`);

--
-- Filtros para la tabla `reencuentroabonos`
--
ALTER TABLE `reencuentroabonos`
  ADD CONSTRAINT `reencuentroabonos_ibfk_1` FOREIGN KEY (`codigoReMatricula`) REFERENCES `reencuentrosmatricula` (`codigoReMatricula`);

--
-- Filtros para la tabla `reencuentrosmatricula`
--
ALTER TABLE `reencuentrosmatricula`
  ADD CONSTRAINT `reencuentrosmatricula_ibfk_1` FOREIGN KEY (`codigoReencuentro`) REFERENCES `reencuentros` (`codigoReencuentro`),
  ADD CONSTRAINT `reencuentrosmatricula_ibfk_2` FOREIGN KEY (`codigoPersona`) REFERENCES `personas` (`codigoPersona`),
  ADD CONSTRAINT `reencuentrosmatricula_ibfk_3` FOREIGN KEY (`guia`) REFERENCES `personas` (`codigoPersona`);

--
-- Filtros para la tabla `roles`
--
ALTER TABLE `roles`
  ADD CONSTRAINT `roles_ibfk_1` FOREIGN KEY (`codigoMinisterio`) REFERENCES `ministerios` (`codigoMinisterio`);

--
-- Filtros para la tabla `usuarios`
--
ALTER TABLE `usuarios`
  ADD CONSTRAINT `usuarios_ibfk_1` FOREIGN KEY (`codigoPersona`) REFERENCES `personas` (`codigoPersona`);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
