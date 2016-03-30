using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RS_7.Functions.Drives;

namespace RS_7.Functions.GroundReaction
{
    public static class Deformations
    {
        public static double[] defs;
    }

    public struct NxParameter
    {
        public double xi;
        public double eta;
        public double zeta;
        
        public double axis_t;
        public double x_ij_t;
        
        public double theta;
        public double phi;
        public double psi;
        
        public double theta_t;
        public double phi_t;
        public double psi_t;
        
        public double x_ij;
        public double y_ij;
        public double z_ij;
        public double l;
        
        public double ground_c;
        public double ground_a;
        
        public double s0;
        public double sX;
        public double sX_t;

        public int cp_xi;
        public int cp_eta;
        public int cp_zeta;

        public double t;
    }

    public class NxXi
    {
        public static double calculate(NxParameter p, out double def_value, out double def_speed)
        {
            double xi = p.xi
                + p.x_ij + p.l
                - p.phi * p.y_ij
                + p.psi * (p.z_ij - p.s0 - p.sX);
            
            double eta = p.eta
                + p.phi * (p.x_ij + p.l)
                + p.y_ij
                - p.theta * (p.z_ij - p.s0 - p.sX);

            double zeta = p.zeta
                - p.psi * (p.x_ij + p.l)
                + p.theta * p.y_ij
                + p.z_ij - p.s0 - p.sX;

            double xi_t = p.axis_t
                + p.x_ij_t
                - p.phi_t * p.y_ij
                + p.psi_t * (p.z_ij - p.s0 - p.sX)
                - p.psi * p.sX_t;

            double N =
                - p.ground_c * (GroundModel.cp[p.cp_xi] - xi)
                - p.ground_a * xi_t;

            def_value = GroundModel.cp[p.cp_xi] - xi;
            def_speed = xi_t;

            if (GroundModel.getZetaAxis(xi, eta) - zeta > 0)
                return N;
            else
                return 0;
        }
    }

    public class NxEta
    {
        public static double calculate(NxParameter p, out double def_value, out double def_speed)
        {
            double xi = p.xi
                + p.x_ij + p.l
                - p.phi * p.y_ij
                + p.psi * (p.z_ij - p.s0 - p.sX);

            double eta = p.eta
                + p.phi * (p.x_ij + p.l)
                + p.y_ij
                - p.theta * (p.z_ij - p.s0 - p.sX);

            double zeta = p.zeta
                - p.psi * (p.x_ij + p.l)
                + p.theta * p.y_ij
                + p.z_ij - p.s0 - p.sX;

            double eta_t = p.axis_t
                + p.phi_t * (p.x_ij + p.l)
                + p.phi * p.x_ij_t
                - p.theta_t * (p.z_ij - p.s0 - p.sX)
                + p.theta * p.sX_t;

            double N =
                -p.ground_c * (GroundModel.cp[p.cp_eta] - eta)
                - p.ground_a * eta_t;

            def_value = GroundModel.cp[p.cp_eta] - eta;
            def_speed = eta_t;

            if (GroundModel.getZetaAxis(xi, eta) - zeta > 0)
                return N;
            else
                return 0;
        }
    }

    public class NxZeta
    {
        public static double calculate(NxParameter p, out double def_value, out double def_speed)
        {
            double xi = p.xi
                + p.x_ij + p.l
                - p.phi * p.y_ij
                + p.psi * (p.z_ij - p.s0 - p.sX);

            double eta = p.eta
                + p.phi * (p.x_ij + p.l)
                + p.y_ij
                - p.theta * (p.z_ij - p.s0 - p.sX);

            double zeta = p.zeta
                - p.psi * (p.x_ij + p.l)
                + p.theta * p.y_ij
                + p.z_ij - p.s0 - p.sX;

            double zeta_t = p.axis_t
                - p.psi_t * (p.x_ij + p.l)
                - p.psi * p.x_ij_t
                + p.theta_t * p.y_ij
                - p.sX_t;

            if (double.IsNaN(GroundModel.cp[p.cp_zeta]) && GroundModel.getZetaAxis(xi, eta) - zeta > 0)
            {
                GroundModel.cp[p.cp_xi] = xi;
                GroundModel.cp[p.cp_eta] = eta;
                GroundModel.cp[p.cp_zeta] = GroundModel.getZetaAxis(xi, eta);
            }
            else if (GroundModel.getZetaAxis(xi, eta) - zeta <= 0)
            {
                GroundModel.cp[p.cp_xi] = double.NaN;
                GroundModel.cp[p.cp_eta] = double.NaN;
                GroundModel.cp[p.cp_zeta] = double.NaN;
            }

            double N =
                - p.ground_c * (GroundModel.cp[p.cp_zeta] - zeta)
                - p.ground_a * zeta_t;

            def_value = GroundModel.cp[p.cp_zeta] - zeta;
            def_speed = zeta_t;

            if (GroundModel.getZetaAxis(xi, eta) - zeta > 0)
            {
                return N;
            }
            else
                return 0;
        }
    }
}
