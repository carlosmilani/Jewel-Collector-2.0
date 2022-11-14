/// <summary>
/// Cria uma Exception para quando o robô tentar se mover para uma posição ocupada.
/// </summary>
public class IntransponivelException : Exception { }

/// <summary>
/// Cria uma Exception para quando o robô tentar se mover para fora do mapa.
/// </summary>
public class SaiuDoMapaException : Exception { }

/// <summary>
/// Cria uma Exception para quando o robô ficar sem energia.
/// </summary>
public class RoboSemEnergiaException : Exception { }